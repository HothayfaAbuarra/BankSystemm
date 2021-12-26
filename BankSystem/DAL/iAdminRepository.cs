using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public interface iAdminRepository
    {
        Guid CreateAccount(int indentity,string email, string name, int age, double balance, string type,int phone);
        bool UpdateAccount(int identitynumber,string email,string name,int age,double balance,string type, int phone);
        Task<bool> DeleteAccount(int identity_number);

    }
}
