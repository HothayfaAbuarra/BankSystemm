using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public interface iTellerRepository
    {
        bool Deposit(int identity_number,double mony);
        bool Withdraw(int identity_numebr,double mony);
        bool CheckBalance(int identity_numebr);
    }
}
