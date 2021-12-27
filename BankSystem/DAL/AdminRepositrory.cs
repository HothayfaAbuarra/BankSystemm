﻿using System;
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
                    db.Customers.Add(customer);
                    db.SaveChanges();

                    var a= db.BankAccounts.Add(account);
                    db.SaveChanges();
                    balance.Account_id = a.Entity.BankAccount_id;

                    db.Balances.Add(balance);
                    db.SaveChanges();
                    
                }
                /*
                Guid g = Guid.NewGuid();
                string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                string previousData= File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<Account>>(previousData);
                Account account = new Account(identitynumber,email,name,age,balance,type,DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),g,true,phone);
                foreach (Account acc in list)
                {
                    if (Convert.ToInt32(acc.identitynumber)==Convert.ToInt32(account.identitynumber))
                    {
                        return new Guid();
                    }
                }
                list.Add(account);
                File.WriteAllText(path, JsonConvert.SerializeObject(list));
                File.AppendAllText(auditFilePath,$"Create new account with identityNumber: {account.identitynumber} ," +
                                                $" email: {account.name}, name: {account.name}," +
                                                $" age: {account.age}, balance: {account.balance}," +
                                                $" AccountType: {account.type}, onDate: {account.date}"+ Environment.NewLine);*/
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
        public bool UpdateAccount(int identity_num,string email,string name,int age,double balance,string type,int phone)
        {
            try
            {
                int i = 0;
                string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                string previousData = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<Account>>(previousData);
                foreach (Account acc in list)
                {
                    if (acc.identitynumber==identity_num)
                    {
                        Console.WriteLine(acc.identitynumber);
                        Console.WriteLine(identity_num);
                        Account newAccount = new Account(identity_num,email,name,age,balance,type,DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),acc.id,true,phone);
                        list[i] = newAccount;
                        File.WriteAllText(path, JsonConvert.SerializeObject(list));
                        File.AppendAllText(auditFilePath, $"Update the account that has identitynumber: {newAccount.identitynumber}," +
                                                            $"email: {newAccount.email}, name: {newAccount.name}, age:{newAccount.age}," +
                                                            $" balance:{newAccount.balance}, AccountType: {newAccount.type}, onDate:{newAccount.date}" + Environment.NewLine);
                        return true;
                    }
                    i += 1;
                }
                return false;
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
                         return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                /* int i = 0;
                 string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                 string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                 string prevData = File.ReadAllText(path);
                 var list = JsonConvert.DeserializeObject<List<Account>>(prevData);
                 foreach (Account acc in list)
                 {
                     if (acc.identitynumber==identity_num)
                     {
                         list[i].active = false;
                         Console.WriteLine("Are you sure that you want to InActive this account?Yes/No");
                         string confirm=Console.ReadLine();
                         if (confirm.ToLower() == "yes")
                         {
                             File.WriteAllText(path, JsonConvert.SerializeObject(list));
                             File.AppendAllText(auditFilePath, $"Inactive the account that has identitynumber: {list[i].identitynumber}," +
                                                           $"email: {list[i].email}, name: {list[i].name}, age:{list[i].age}," +
                                                           $" balance:{list[i].balance}, AccountType: {list[i].type}, onDate:{list[i].date} " +  Environment.NewLine);
                             return true;
                         }
                         if (confirm.ToLower() == "no")
                         {
                             return false;
                         }
                     }
                     i += 1;
                 }
                 return false;*/
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