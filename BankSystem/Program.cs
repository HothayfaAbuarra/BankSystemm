using System;

namespace BankSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld");
            Program start = new Program();
            bool Exit = false;
            while (Exit == false)
            {
                Console.WriteLine("admin/teller");
                string type = Console.ReadLine();
                if (type.ToLower() == "exit")
                {
                    Exit = true;
                }
                switch (type)
                {
                    case "admin":
                        start.AdminMenu();
                        break;
                    case "teller":
                        start.TellerMenu();
                        break;
                }
            }
        }
        #region Admin Menu Method
        public void AdminMenu()
        {
            AdminServices bankcontroller = new AdminServices();
            Console.WriteLine("Hello Welcome to our Bank");
            bool Exit = false;
            while (Exit == false)
            {
                Console.WriteLine("1-For create an account");
                Console.WriteLine("2-For Update an account");
                Console.WriteLine("3-For Delete an account");
                Console.WriteLine("Type exit to exit");
                string pick = Console.ReadLine();
                if (pick.ToLower() == "exit")
                {
                    Exit = true;
                }
                switch (pick)
                {
                    case "1":
                        bankcontroller.CreateAccount();
                        break;
                    case "2":
                        bankcontroller.UpdateAccount();
                        break;
                    case "3":
                        bankcontroller.DeleteAccount();
                        break;
                }
            }
            Console.WriteLine("Press exit to exit");
        }
        #endregion

        #region Teller Menu Method
        public void TellerMenu()
        {
            TellerServices ts = new TellerServices();
            Console.WriteLine("1-Deposit mony");
            Console.WriteLine("2-Withdrow mony");
            string pick = Console.ReadLine();
            switch (pick)
            {
                case "1":
                    Console.WriteLine(ts.deposit());
                    break;
                case "2":
                    Console.WriteLine(ts.withdraw());
                    break;
            }
        }
        #endregion
    }
}
