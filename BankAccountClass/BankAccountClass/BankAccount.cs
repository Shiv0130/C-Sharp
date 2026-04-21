using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClass
{
    public abstract class BankAccount
    {
        //Encapsulation (protected so only child classes can access)
        protected double balance;

        public void Deposit(double amount) 
        {
            if (amount > 0)
                balance += amount;
        }
        public double GetBalance() 
        { 
            return balance; 
        }

        //Abstraction
        public abstract void Withdraw(double amount);
    }
}
