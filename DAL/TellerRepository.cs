using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using common;
using System.Linq;
namespace DAL
{
    public class TellerRepository : iTellerRepository
    {
        BankdbContext db = new BankdbContext();

        #region Method for deposit
        /*
         *Input:IdentityNumber and mony
         *output:if sucess returned true,increased the balance of the account by the entered mony and if failed returned false
         */
        public bool Deposit(int identity_number,double mony)
        {
            try
            {
                var result = (from customer in db.Customers
                                where customer.Customer_identity == identity_number
                                select customer).FirstOrDefault();
                   
                if (result == null)
                {
                    return false;
                }
                else
                {
                    var Balance = (from bal in db.Balances
                                    where bal.Account_id == (from acc in db.BankAccounts
                                                            where acc.CustomersCustomer_id == result.Customer_id
                                                            select acc).FirstOrDefault().BankAccount_id
                                    select bal).FirstOrDefault();
                    Balance.balance = Balance.balance + mony;
                    db.SaveChanges();
                    return true;
                }
                
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
                var result = (from customer in db.Customers
                                where customer.Customer_identity == identity_number
                                select customer).FirstOrDefault();

                if (result == null)
                {
                    return false;
                }
                else
                {
                    var Balance = (from bal in db.Balances
                                    where bal.Account_id == (from acc in db.BankAccounts
                                                            where acc.CustomersCustomer_id == result.Customer_id
                                                            select acc).FirstOrDefault().BankAccount_id
                                    select bal).FirstOrDefault();
                    Balance.balance = Balance.balance - mony;
                    if (Balance.balance < 0)
                    {
                        return false;
                    }
                    db.SaveChanges();
                    return true;
                }
                
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
