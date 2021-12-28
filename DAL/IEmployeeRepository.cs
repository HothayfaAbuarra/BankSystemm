using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface IEmployeeRepository
    {
        Guid CreateAccount(Employees Employee);
        bool DeleteAccount(int identityNumber);
    }
}
