using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClass
{
    public class CurrentAccount : BankAccount
    {
        private double overdraftLimit = 500;
        //Polymorphism (different behaviour)
        public override void Withdraw(double amount)
        {
            if (amount <= balance+ overdraftLimit) 
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful (Current with overdraft)");
            } 
            else 
            { 
                Console.WriteLine("Overdraft limit exceeded");
            }
        }
    }
}
