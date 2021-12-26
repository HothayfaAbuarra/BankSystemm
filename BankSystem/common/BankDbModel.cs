using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.common
{
    public class BankAccounts
    {
        [Key]
        public int BankAccount_id { get; set; }
        [ForeignKey("FK_Customer_id")]
        public string CustomersCustomer_id { get; set; }
        public string Account_type { get; set; }
        public string Account_Date { get; set; }
        public bool Account_Status { get; set; }
    }
    public class Customers
    {
        [Key]
        public string Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }
        public int Customer_identity { get; set; }
        public int Customer_age { get; set; }
        public int Customer_phone { get; set; }
        public bool Customer_status { get; set; }
        public List<BankAccounts> BankAccounts { get; set; }

    }

    public class Balances
    {
        [Key]
        public int Balance_id { get; set; }
        public double balance { get; set; }
        public int Account_id { get; set; }
    }
    public class Employees
    {
        [Key]
        public int Employee_id { get; set; }
        [ForeignKey("Department_id")]
        public int Department_id { get; set; }
        public int Role_id { get; set; }
        public string Employee_username { get; set; }
        public string Employee_password { get; set; }
        public string Employee_Email { get; set; }
    }
    public class Departments
    {
        [Key]
        public int Department_id { get; set; }
        public string Department_name { get; set; }
    }
    public class Roles
    {
        [Key]
        public int Role_id { get; set; }
        public string Role_name { get; set; }
    }
}
