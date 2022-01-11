using common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        BankdbContext db = new BankdbContext();

        #region Method for Insert Employee to DB
        public Guid CreateAccount(Employees Employee)
        {
           
            try
            {
                var result = (from emp in db.Employees
                                where emp.Employee_identity == Employee.Employee_identity
                                select emp).FirstOrDefault();
                if (result!=null)
                {
                    return new Guid();
                }
                else
                {
                    Guid guid = Guid.NewGuid();
                    Employee.Employee_id = guid;
                    Employee.Employee_Status = true;
                    db.Add(Employee);
                    db.SaveChanges();
                    return guid;
                }         
                    
            }
            catch (Exception e)
            {
                throw new Exception("Exciption:"+ e.Message.ToString());
            }
            
        }
        #endregion

        #region Method for Inactive the account
        public bool DeleteAccount(int identityNumber)
        {
            try
            {
                var resultEmployee = (from employee in db.Employees
                                      where employee.Employee_identity == identityNumber
                                      select employee).FirstOrDefault();
                if (resultEmployee==null)
                {
                    return false;
                }

                if (resultEmployee.Employee_Status == false)
                {
                    return false;
                }
                resultEmployee.Employee_Status = false;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("Exciption :" + e.InnerException.Message.ToString());
            }
            
        }
        #endregion

        #region Method for test login
        public bool Login(string username,string password)
        {
           
            return true;
        }
        #endregion
    }
}
