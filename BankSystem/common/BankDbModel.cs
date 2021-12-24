using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.common
{
    public class Customers
    {
        [Key]
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }
        public int Customer_identity { get; set; }
        public int Customer_age { get; set; }
        public int Customer_phone { get; set; }
        public bool Customer_status { get; set; }
    }
    public class BankAccounts
    {
        [Key]
        public int BankAccount_id { get; set; }
        [ForeignKey("Customer_id")]
        public int Customer_id { get; set; }
        public string Account_type { get; set; }
        public bool Account_Status { get; set; }
    }
    public class Balances
    {
        [Key]
        public int Balance_id { get; set; }
        public double balance { get; set; }
        [ForeignKey("BankAccount_id")]
        public int Account_id { get; set; }
    }
    public class Employees
    {
        [Key]
        public int Employee_id { get; set; }
        [ForeignKey("Department_id")]
        public int Department_id { get; set; }
        [ForeignKey("Role_id")]
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
