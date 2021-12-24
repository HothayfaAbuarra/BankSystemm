using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Data;
using System.Data.SqlClient;

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
        #region Create Account Method
        /*
         Input:IdentityNumber, email,name,age,balance,type
         output:if sucess returned true,the unique key for the newly created account and if failed returned false
         */
        public Guid CreateAccount(int identitynumber,string email,string name,int age,double balance,string type,int phone)
        { 
            string conn = "Data Source=SD-PC-W10-AABUA;Integrated Security=True";
            SqlConnection sql = new SqlConnection(conn);
            Guid g = Guid.NewGuid();                   
            string query = $"INSERT INTO BankSystem.dbo.Customer (Customer_id,Customer_age,Customer_phonenumber,Customer_identity,Customer_status,Customer_email) VALUES ({1},{age},{phone},{identitynumber},{1},{@email.ToString()}) ";
            Console.WriteLine(query);
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand(query, sql);
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
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
                return g;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
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
                int i = 0;
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
                return false;
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