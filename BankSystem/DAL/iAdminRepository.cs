using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.common;
namespace BankSystem
{
    public interface iAdminRepository
    {
        Guid CreateAccount(Customers customer,BankAccounts account,Balances balance);
        bool UpdateAccount(int identitynumber,string email,string name,int age,double balance,string type, int phone);
        bool DeleteAccount(int identity_number);

    }
}
