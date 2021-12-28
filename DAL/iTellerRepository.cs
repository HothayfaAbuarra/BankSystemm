using System;
using System.Collections.Generic;
using System.Text;
using common;

namespace DAL
{
    public interface iTellerRepository
    {
        bool Deposit(int identity_number,double mony);
        bool Withdraw(int identity_numebr,double mony);
    }
}
