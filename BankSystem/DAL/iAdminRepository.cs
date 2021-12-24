using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public interface iAdminRepository
    {
        Guid CreateAccount(int indentity,string email, string name, int age, double balance, string type,int phone);
        bool UpdateAccount(int identitynumber,string email,string name,int age,double balance,string type, int phone);
        bool DeleteAccount(int identity_number);

    }
}
