using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BankSystem.common;
namespace BankSystem
{
    public class AdminRepositrory : iAdminRepository
    {
        private static AdminRepositrory bankrepo;
        private AdminRepositrory()
        {

        }
        public static AdminRepositrory GetInstance()
        {
            if (bankrepo == null)
            {
                bankrepo = new AdminRepositrory();
            }
            return bankrepo;
        }
        #region GetAllBankAccounts Method
        public List<Customers> Getdata()
        {
            using (var db = new BankSystem.common.BankdbContext())
            {
                var Customers = db.Customers.Select(s=>s).ToList();
                return Customers;
            }
        }
        #endregion

        #region Create Account Method
        /*
         Input:IdentityNumber, email,name,age,balance,type
         output:if sucess returned true,the unique key for the newly created account and if failed returned false
         */
        public Guid CreateAccount(Customers customer,BankAccounts account,Balances balance)
        {                 
            try
            {
                var result = Getdata();
                foreach (Customers ccustomer in result)
                {
                    if (ccustomer.Customer_identity == customer.Customer_identity)
                    {
                        return new Guid();
                    }
                }
                using (var db = new BankdbContext())
                {
                    //Add a customer
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    //add an account
                    var a= db.BankAccounts.Add(account);
                    db.SaveChanges();

                    //add a balance
                    balance.Account_id = a.Entity.BankAccount_id;
                    db.Balances.Add(balance);
                    db.SaveChanges();
                    
                }
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                File.AppendAllText(auditFilePath, $"Create new account with identityNumber: {customer.Customer_identity} ," +
                                                $" email: {customer.Customer_email}, name: {customer.Customer_name}," +
                                                $" age: {customer.Customer_age}, balance: {balance.balance}," +
                                                $" AccountType: {account.Account_type}, onDate: {account.Account_Date}" + Environment.NewLine);
                Guid newGuid = Guid.Parse(customer.Customer_id);
                return newGuid;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.WriteLine(e.InnerException.ToString());

                return new Guid();
                
            }
            
        }
        #endregion

        #region Update Account Method
        /*
         Input:IdentityNumber, email,name,age,balance,type
         output:if sucess returned true and if failed returned false
         */
        public bool UpdateAccount(Customers customer,BankAccounts account)
        {
            try
            {
                using (var Db = new BankdbContext())
                {
                    var result = from cust in Db.Customers
                                 where cust.Customer_identity == customer.Customer_identity
                                 select cust;
                    if (result.Count() == 0)
                    {
                        return false;
                    }
                    else
                    { 
                        var updated = (from cust in Db.Customers
                                        from acc in Db.BankAccounts
                                        where cust.Customer_identity == customer.Customer_identity && acc.CustomersCustomer_id == cust.Customer_id
                                        select new { cust, acc }).FirstOrDefault();
                        //update customer
                        updated.cust.Customer_email = customer.Customer_email;
                        updated.cust.Customer_age = customer.Customer_age;
                        updated.cust.Customer_name = customer.Customer_name;
                        updated.cust.Customer_phone = customer.Customer_phone;

                        //update account
                        updated.acc.Account_type = account.Account_type;
                        updated.acc.Account_Date = account.Account_Date;
                        Db.SaveChanges();
                    }
                    string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                    File.AppendAllText(auditFilePath, $"Update the account that has identitynumber: {customer.Customer_identity}," +
                                                               $"email: {customer.Customer_email}, name: {customer.Customer_name}, age:{customer.Customer_age}," +
                                                               $" AccountType: {account.Account_type}, onDate:{account.Account_Date}" + Environment.NewLine);
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion

        #region Delete Account Method
        /*
         Input:IdentityNumber
         output:if sucess returned true and if failed returned false
         */
        public bool DeleteAccount(int identity_num)
        {
            try
            {
                using (var Db = new BankdbContext())
                {
                    var result=(from cust in Db.Customers
                               from acc in Db.BankAccounts
                               where cust.Customer_identity==identity_num && acc.CustomersCustomer_id==cust.Customer_id
                               select new { cust , acc}).FirstOrDefault();
                    if (result != null)
                    {
                        result.cust.Customer_status = false;
                        result.acc.Account_Status = false;
                        Db.SaveChanges();
                        string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                        File.AppendAllText(auditFilePath,   $"Inactive the account that has identitynumber: {result.cust.Customer_identity}," +
                                                            $"email: {result.cust.Customer_email}, name: {result.cust.Customer_name}, age:{result.cust.Customer_age}," +
                                                            $"AccountType: {result.acc.Account_type}, onDate:{result.acc.Account_Date} " + Environment.NewLine);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion
    }
}