using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class BankAccount
    {
        private string _accountNumber;
        public string Owner { get; set; }
        protected decimal Balance { get; set; }
        internal DateTime CreatedDate { get;set }

        private void UpdateBalance() { }
        public void Deposit(decimal amount) { }
    }
}
