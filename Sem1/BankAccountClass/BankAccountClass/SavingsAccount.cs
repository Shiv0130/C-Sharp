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
            if (amount <= balance) 
            { 
                balance -= amount;
                Console.WriteLine("Withdrawal successful (Savings)");
            }
            else 
            { 
                Console.WriteLine("Insufficient funds (Savings)");
            }
        }
    }
}
