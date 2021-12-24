using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Account
    {
        public int identitynumber;
        public string email;
        public string name;
        public int age;
        public double balance;
        public string type;
        public string date;
        public Guid id;
        public bool active;
        public int phone;
        public Account(int identitynumber,string email,string name,int age,double balance,string type,string date,Guid id,bool active,int phone)
        {
            this.identitynumber = identitynumber;
            this.email = email;
            this.name = name;
            this.age = age;
            this.balance = balance;
            this.type = type;
            this.date = date;
            this.id = id;
            this.active = active;
            this.phone = phone;
        }

    }
}
