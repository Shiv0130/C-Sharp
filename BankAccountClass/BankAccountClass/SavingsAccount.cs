using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClass
{
    public class SavingsAccount : BankAccount
    {
        //Polymorphism (override)
        public override void Withdraw(double amount)
        {
            balance -= amount;
        }
    }
}
