using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class AdminServices : iAdminServices
    {
        private int _identitynumber;
        private string _Email;
        private string _Name;
        private int _Age;
        private double _Balance;
        private string _Type;
        private int _phone;
        #region Create Account Method
        public void CreateAccount()
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
                while (validEmail== false)
                {
                    _Email = Console.ReadLine();
                    validEmail = Regex.IsMatch(_Email, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                    if (validEmail==false) {
                        Console.WriteLine("Please Enter a valid email:");
                    }
                }
                //EndEmail

                //Name Field
                Console.WriteLine("Please Enter the name");
                bool validName=false ;
                while (validName==false)
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
                //EndName

                //Age Field
                Console.WriteLine("Please Enter the age:");
                bool validAge = false;
                while (validAge == false)
                {
                var age = Console.ReadLine();
                bool validone = Regex.IsMatch(age,@"^\d+$");
                if (validone == true)
                {
                    _Age = Convert.ToInt32(age);
                    if (_Age < 18)
                    {
                        validAge = false;
                        Console.WriteLine("The age must be greater than 18:");
                    }
                    else
                    {
                        validAge = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a Valid number:");
                }  
                }
                //EndAge

                //Balance Field
                Console.WriteLine("Please Enter the balance");
                bool validBalance = false;
                while (validBalance == false)
                {
                var balance = Console.ReadLine();
                bool validone = Regex.IsMatch(balance, @"^\d+$");
                if (validone == true)
                {
                    
                    _Balance = Convert.ToDouble(balance);
                    if (_Balance < 0)
                    {
                        validBalance = false;
                        Console.WriteLine("The balance must be greater than 0:");
                    }
                    else
                    {
                        validBalance = true;
                    }

                }
                else
                {
                    Console.WriteLine("Please Enter a Valid number:");
                }

            }
            //EndBalance

            //Type Field
                Console.WriteLine("Please pick the type:");
                Console.WriteLine("1-current bank account");
                Console.WriteLine("2-Savings bank account");
                string typePicker = Console.ReadLine();
                bool ValidType=false;
                while (ValidType == false)
                {
                    if (typePicker == "1" || typePicker =="2")
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
                        _Type = "current";
                        break;
                    case "2":
                        _Type = "saving";
                        break;
                }
                //EndType


                AdminRepositrory bankrepo = AdminRepositrory.GetInstance();
                Guid result = bankrepo.CreateAccount(_identitynumber, _Email, _Name, _Age, _Balance, _Type,_phone);
            if (result==new Guid())
            {
                Console.WriteLine("There is an account of this identity number");
            }
            else
            {
                Console.Write(Convert.ToString(result));
            }
            
                
                    
        }
        #endregion

        #region Update Account Method
        public void UpdateAccount()
        {
            Console.WriteLine("Please Enter the identity number for the account that you want to update");
            var iden_num = Console.ReadLine();
            bool valid_iden_num=false;
            while (valid_iden_num == false)
            {
                valid_iden_num = Regex.IsMatch(iden_num, @"^\d{9}$");
                if (valid_iden_num==true)
                {
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

                    //Name Field
                    Console.WriteLine("Please Enter the name");
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
                    //EndName

                    //Age Field
                    Console.WriteLine("Please Enter the age:");
                    bool validAge = false;
                    while (validAge == false)
                    {
                        var age = Console.ReadLine();
                        bool validone = Regex.IsMatch(age, @"^\d+$");
                        if (validone == true)
                        {
                            _Age = Convert.ToInt32(age);
                            if (_Age < 18)
                            {
                                validAge = false;
                                Console.WriteLine("The age must be greater than 18:");
                            }
                            else
                            {
                                validAge = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please Enter a Valid number:");
                        }
                    }
                    //EndAge

                    //Balance Field
                    Console.WriteLine("Please Enter the balance");
                    bool validBalance = false;
                    while (validBalance == false)
                    {
                        var balance = Console.ReadLine();
                        bool validone = Regex.IsMatch(balance, @"^\d+$");
                        if (validone == true)
                        {

                            _Balance = Convert.ToDouble(balance);
                            if (_Balance < 0)
                            {
                                validBalance = false;
                                Console.WriteLine("The balance must be greater than 0:");
                            }
                            else
                            {
                                validBalance = true;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Please Enter a Valid number:");
                        }

                    }
                    //EndBalance

                    //Type Field
                    Console.WriteLine("Please pick the type:");
                    Console.WriteLine("1-current bank account");
                    Console.WriteLine("2-Savings bank account");
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
                            _Type = "current";
                            break;
                        case "2":
                            _Type = "saving";
                            break;
                    }
                    //EndType
                    AdminRepositrory bankrepo = AdminRepositrory.GetInstance();
                    int identity_number = Convert.ToInt32(iden_num);
                    if (bankrepo.UpdateAccount(identity_number, _Email, _Name, _Age, _Balance, _Type,_phone)==true)
                    {
                        Console.WriteLine("The Account Updated Succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed Update the account");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid identity number");
                    iden_num = Console.ReadLine();
                }
            }
            
        }
        #endregion

        #region Delete Account Method
        public async void DeleteAccount()
        {
            Console.WriteLine("Please Enter the identity number for the account that you want to delete:");
            var iden_num = Console.ReadLine();
            bool valid_iden_num = false;
            while (valid_iden_num == false)
            {
                valid_iden_num = Regex.IsMatch(iden_num, @"^\d{9}$");
                if (valid_iden_num == true)
                {
                    AdminRepositrory bankrepo = AdminRepositrory.GetInstance();
                    if (await bankrepo.DeleteAccount(Convert.ToInt32(iden_num))==true)
                    {
                        Console.WriteLine("Account set to Inactive succsfully");
                    }
                    else
                    {
                        Console.WriteLine("Faild to Inactive the account");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter valid identity number:");
                    iden_num = Console.ReadLine();
                }
            }
        }
        #endregion

    }
}
