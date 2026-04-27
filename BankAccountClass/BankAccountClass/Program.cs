/*
 * 1. Abstraction
 * abstract class BankAccount
 * Forces all account to implement withdraw()
 * 
 * 2. Encapsulation
 * protected double balance
 * Controlled via Deposit() and GetBalance()
 * 
 * 3.Inheritance
 * SavingsAccount : BankAccount
 * CurrentAccount : BankAccount
 * 
 * 4. Polymorphism
 * withdraw() behaves differently:
 * Savings - strict balance check
 * Current - allows overdraft
 */

using BankAccountClass;

BankAccount acc1 = new SavingsAccount();
acc1.Deposit(1000);
acc1.Withdraw(1200); // Savings - should fail
Console.WriteLine("Balance: " + acc1.GetBalance());

Console.WriteLine();

BankAccount acc2 = new CurrentAccount();
acc2.Deposit(1000);
acc2.Withdraw(1200); // Current - should allow overdraft
Console.WriteLine("Balance: " + acc2.GetBalance());