using BankApp.Models;
using System;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Банк ===");

            var testAccount = new TestAccount("ACC-001", "Иван Петров", 1000);
            testAccount.DisplayInfo();

            Console.ReadLine();
        }
    }

    public class TestAccount : BankAccount
    {
        public TestAccount(string accountNumber, string owner, decimal initialBalance)
            : base(accountNumber, owner, initialBalance) { }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Счёт: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} Руб.");
        }
    }
}
