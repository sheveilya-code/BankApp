using BankApp.Models;
using BankApp.Services;
using System;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Банк ===");

            var bank = new Bank();

            var regularAccount = new BankAccountConcrete("ACC-003", "Алексей Сидоров", 3000);
            var savingsAccount = new SavingsAccount("SAV-001", "Елена Козлова", 5000);
            bank.AddAccount(regularAccount);
            bank.AddAccount(savingsAccount);
            
            bank.DisplayAllAccounts();

            Console.ReadLine();
        }
    }

    public class BankAccountConcrete : BankAccount
    {
        public BankAccountConcrete(string accountNumber, string owner, decimal initialBalance)
            : base(accountNumber, owner, initialBalance) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Обычный счёт: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} Руб.");
        }
    }
}
