using BankApp.Models;
using System;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Банк ===");
            try
            {
                var account = new TestAccount("ACC-002", "Мария Иванова", 2000);
                Console.WriteLine("Счёт создан успешно!");
                account.DisplayInfo();

                Console.WriteLine("\nПополнение на 500...");
                account.Deposit(500);
                account.DisplayInfo();

                Console.WriteLine("\nСнятие 300...");
                account.Withdraw(300);
                account.DisplayInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
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
