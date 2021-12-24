using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace BankSystem
{
    public class TellerServices : itellerServices
    {
        #region Method For Deposit
        public string deposit()
        {
            TellerRepository tr = new TellerRepository();
            //enter the id
            Console.WriteLine("Please enter the identity number to the account you want to deposit:");
            string id="";
            bool valid_idnum=false;
            while (valid_idnum==false)
            {
                id = Console.ReadLine(); 
                valid_idnum = Regex.IsMatch(id, @"^\d{9}$");
                if (valid_idnum == false)
                {
                    Console.WriteLine("Please Enter a valid idnumber:");
                }
            }
            //end
            //check and log how much the balance for this account can deposit or not
            bool res = tr.CheckBalance(Convert.ToInt32(id));
            if (res == false)
            {
                return "Failed";
            }
            //
            //enter the mony that you want to deposit
            string mony ="";
            Console.WriteLine("Please enter the amount of mony that you want to deposit:");
            bool valid_mony = false;
            while (valid_mony==false)
            {
                mony=Console.ReadLine();
                valid_mony = Regex.IsMatch(mony, @"^\d+(\.\d+)*$");
                if (valid_mony == false)
                {
                    Console.WriteLine("Please Enter a valid mony:");
                }
            }
            //end
            bool result = tr.Deposit(Convert.ToInt32(id),Convert.ToDouble(mony));
            if (result==false)
            {
                return "Faild deposit mony";
            }
            else
            {
                return "Your deposit mony succesfully";
            }
            
        }
        #endregion

        #region Method For Withdraw
        public string withdraw()
        {
            TellerRepository tr = new TellerRepository();
            //enter the id number
            Console.WriteLine("Please Enter an identity number for the account that you want to withdraw from it:");
            string id = "";
            bool valid_idnum = false;
            while (valid_idnum == false)
            {
                id = Console.ReadLine();
                valid_idnum = Regex.IsMatch(id, @"^\d{9}$");
                if (valid_idnum == false)
                {
                    Console.WriteLine("Please Enter a valid idnumber:");
                }
            }
            //
            //check and log how much the balance for this account can deposit or not
            bool res = tr.CheckBalance(Convert.ToInt32(id));
            if (res == false)
            {
                return "Failed";
            }
            Console.WriteLine(res);
            //

            //enter the mony
            string mony = "";
            Console.WriteLine("Please enter the amount of mony that you want to withdraw:");
            bool valid_mony = false;
            while (valid_mony == false)
            {
                mony = Console.ReadLine();
                valid_mony = Regex.IsMatch(mony, @"^\d+(\.\d+)*$");
                if (valid_mony == false)
                {
                    Console.WriteLine("Please Enter a valid mony:");
                }
            }
            //
            bool result = tr.Withdraw(Convert.ToInt32(id), Convert.ToDouble(mony));
            if (result==false)
            {
                return "Falied withdraw mony";
            }
            else
            {
                return "Widraw is done sucessfully";
            }
        }
        #endregion
    }
}
