using BankApp.Models;
using System;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Банк ===");

            var regularAccount = new BankAccountConcrete("ACC-003", "Алексей Сидоров", 32000);
            var savingsAccount = new SavingsAccount("SAV-001", "Елена Козлова", 5000);

            Console.WriteLine("\n=== Обычный счёт ===");
            regularAccount.DisplayInfo();

            Console.WriteLine("\n=== Сберегательный счёт ===");
            savingsAccount.DisplayInfo();

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
