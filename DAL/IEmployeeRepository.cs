using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface IEmployeeRepository
    {
        Guid CreateAccount(Employees Employee);
        bool Login(string username, string password);
        bool DeleteAccount(int identityNumber);
    }
}
