using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace BankSystem
{
    public class TellerRepository : iTellerRepository
    {
        #region Method for deposit
        /*
         *Input:IdentityNumber and mony
         *output:if sucess returned true,increased the balance of the account by the entered mony and if failed returned false
         */
        public bool Deposit(int identity_number,double mony)
        {
            try
            {
                int i = 0;
                string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                string prevdata = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<Account>>(prevdata);
                foreach (Account acc in list)
                {
                    if (acc.identitynumber==identity_number)
                    {
                        Account account = list[i];
                        account.balance = account.balance + mony;
                        list[i] = account;
                        File.WriteAllText(path,JsonConvert.SerializeObject(list));
                        File.AppendAllText(auditFilePath, $"Deposit to the account that has identitynumber: {account.identitynumber}," +
                                                         $"email: {account.email}, name: {account.name}, age:{account.age}," +
                                                         $" balance:{account.balance}, AccountType: {account.type}, onDate:{account.date}" + Environment.NewLine);
                        return true;
                    }
                    i += 1;
                }
                Console.WriteLine("There is no account for this identity number");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion

        #region Method for withdraw
        /*
         *Input:IdentityNumber and mony
         *output:if sucess returned true,decreased the balance of the account by the entered mony and if failed returned false,
         *if the result of the (balance-mony) returned false
         */
        public bool Withdraw(int identity_number, double mony)
        {
            try
            {
                int i = 0;
                string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                string prevdata = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<Account>>(prevdata);
                foreach (Account acc in list)
                {
                    if (acc.identitynumber == identity_number)
                    {
                        Account account = list[i];
                        double prevBalance = account.balance;
                        account.balance = account.balance - mony;
                        if (account.balance < 0)
                        {
                            Console.WriteLine("This account exceed the limit");
                            return false;
                        }
                        list[i] = account;
                        File.WriteAllText(path, JsonConvert.SerializeObject(list));
                        File.AppendAllText(auditFilePath, $"Withdraw from the account that has identitynumber: {account.identitynumber}," +
                                                         $"email: {account.email}, name: {account.name}, age:{account.age}," +
                                                         $" balance:{account.balance}, AccountType: {account.type}, onDate:{account.date}, Previous Balance is: {prevBalance}" + Environment.NewLine);
                        return true;
                    }
                    i += 1;
                }
                Console.WriteLine("There is no account for this identity number");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion

        #region Method for check the balance
        public bool CheckBalance(int identity_numebr)
        {
            try
            {
                string path = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\memory.json";
                string prevData=File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<Account>>(prevData);
                foreach (Account acc in list)
                {
                    if (acc.identitynumber == identity_numebr)
                    {
                        Console.WriteLine($"Current balance for this account is: {acc.balance}");
                        return true;
                    }
                }
                Console.WriteLine("There is no account for this identity number");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion
    }
}
