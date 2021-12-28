using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using common;
using DAL;

namespace banksystem_v2
{
    public class EmployeeService : IEmployeeService
    {
        private string _Email;
        private string _Name;
        private string _Password;
        private int _Department;
        private int _Role;
        private int _identitynumber;
        private int _phone;

        #region Method For CreateEmployee
        public void CreateEmployee()
        {
            //Identitynumber Field
            Console.WriteLine("Please Enter the Identitynumber:");
            bool validIden = false;
            while (validIden == false)
            {
                var idennumber = Console.ReadLine();
                bool validone = Regex.IsMatch(idennumber, @"^\d{9}$");
                if (validone == true)
                {
                    _identitynumber = Convert.ToInt32(idennumber);
                    validIden = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid number:");
                }
            }
            //EndIdentitynumber

            //PhoneNumber Field
            Console.WriteLine("Please Enter the phonenumber:");
            bool validPhn = false;
            while (validPhn == false)
            {
                var phnumber = Console.ReadLine();
                bool validone = Regex.IsMatch(phnumber, @"^\d{10}$");
                if (validone == true)
                {
                    _phone = Convert.ToInt32(phnumber);
                    validPhn = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid PhoneNumber:");
                }
            }
            //EndPhoneNumber
            //Email Field
            Console.WriteLine("Please Enter the Email:");
            bool validEmail = false;
            while (validEmail == false)
            {
                _Email = Console.ReadLine();
                validEmail = Regex.IsMatch(_Email, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                if (validEmail == false)
                {
                    Console.WriteLine("Please Enter a valid email:");
                }
            }
            //EndEmail
            //username Field
            Console.WriteLine("Please Enter the username");
            bool validName = false;
            while (validName == false)
            {
                _Name = Console.ReadLine();
                if (_Name == "")
                {
                    Console.WriteLine("Name field is required");
                }
                else
                {
                    validName = Regex.IsMatch(_Name, "^[A-Za-z ]+$");
                    if (validName == false)
                    {
                        Console.WriteLine("Allow Just Alpha Characters and spaces:");
                    }
                }
            }
            //EndUsername
            //Password Field
            Console.WriteLine("Please Enter the password");
            bool validpass = false;
            while (validpass == false)
            {
                _Password = Console.ReadLine();
                if (_Password == "")
                {
                    Console.WriteLine("Enter password");
                }
                else
                {
                    validpass = Regex.IsMatch(_Password, "^[A-Za-z]+$");
                    if (validpass == false)
                    {
                        Console.WriteLine("Allow Just Alpha Characters and spaces:");
                    }
                }
            }
            //EndPassword
            //Department Type
            Console.WriteLine("Please pick the Department:");
            Console.WriteLine("1-Admin department");
            Console.WriteLine("2-Teller department");
            string typePicker = Console.ReadLine();
            bool ValidType = false;
            while (ValidType == false)
            {
                if (typePicker == "1" || typePicker == "2")
                {
                    ValidType = true;
                }
                else
                {
                    Console.WriteLine("Please pick 1 or 2 choices:");
                    typePicker = Console.ReadLine();
                }
            }
            switch (typePicker)
            {
                case "1":
                    _Department = 1;
                    break;
                case "2":
                    _Department = 2;
                    break;
            }
            //EndType
            //RoleType
            Console.WriteLine("Please pick the Role:");
            Console.WriteLine("1-Admin Role");
            Console.WriteLine("2-Teller Role");
            string typePickerRole = Console.ReadLine();
            bool ValidTypeRole = false;
            while (ValidTypeRole == false)
            {
                if (typePickerRole == "1" || typePickerRole == "2")
                {
                    ValidTypeRole = true;
                }
                else
                {
                    Console.WriteLine("Please pick 1 or 2 choices:");
                    typePicker = Console.ReadLine();
                }
            }
            switch (typePicker)
            {
                case "1":
                    _Role = 1;
                    break;
                case "2":
                    _Role = 2;
                    break;
            }
            //EndType
            Employees employee = new Employees {Department_id=_Department,Employee_Email=_Email,Employee_username=_Name,Employee_password=_Password,Role_id=_Role,Employee_identity=_identitynumber,Employee_phone=_phone };
            EmployeeRepository er = new EmployeeRepository();
            Guid result=er.CreateAccount(employee);
            if (result==new Guid())
            {
                Console.WriteLine("Faild to add account(There is account for this identity number)");
            }
            else
            {
                Console.WriteLine("Insert account successfully"+result.ToString());
            }
        }
        #endregion

        #region Method for DeleteEmployee
        public void DeleteEmployee()
        {
            EmployeeRepository er = new EmployeeRepository();
            //Identitynumber Field
            Console.WriteLine("Please Enter the Identitynumber of the employee account that you want to delete:");
            bool validIden = false;
            while (validIden == false)
            {
                var idennumber = Console.ReadLine();
                bool validone = Regex.IsMatch(idennumber, @"^\d{9}$");
                if (validone == true)
                {
                    _identitynumber = Convert.ToInt32(idennumber);
                    validIden = true;
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid identitynumber:");
                }
            }
            //EndIdentitynumber
            bool result=er.DeleteAccount(_identitynumber);
            if (result==true)
            {
                Console.WriteLine("The accont is inactive sucessfully");
            }
            else
            {
                Console.WriteLine("Faild inactive account");
            }
        }
        #endregion
    }
}
