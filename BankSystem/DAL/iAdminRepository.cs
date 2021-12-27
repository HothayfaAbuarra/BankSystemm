using System;
using System.Collections.Generic;
using System.Text;
using BankSystem.common;
namespace BankSystem
{
    public interface iAdminRepository
    {
        Guid CreateAccount(Customers customer,BankAccounts account,Balances balance);
        bool UpdateAccount(Customers customer,BankAccounts account);
        bool DeleteAccount(int identity_number);

    }
}
