using BankApp.Models;
using BankApp.Services;
using System;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Банк ===");

            var bank = new Bank();

            var account1 = new BankAccountConcrete("ACC-004", "Иван Петров", 1000);
            var account2 = new SavingsAccount("SAV-002", "Мария Иванова", 2000);
            var account3 = new BankAccountConcrete("ACC-005", "Анна Сидорова", 5000);
            var account4 = new SavingsAccount("SAV-003", "Пётр Козлов", 7000);
            bank.AddAccount(account1);
            bank.AddAccount(account2);
            bank.AddAccount(account3);
            bank.AddAccount(account4);

            Console.WriteLine("\n=== Сберегательные счета ===");
            var savings = bank.GetSavingsAccounts();
            foreach (var acc in savings)
            {
                acc.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine("=== Счета с балансом > 3000 ===");
            var highBalance = bank.GetAccountsWithBalanceAbove(3000);
            foreach (var acc in highBalance)
            {
                acc.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine($"Общая сумма на всех счетах: {bank.GetTotalBalance()} Руб.");

            Console.WriteLine("\nСчета владельцев с фамилией 'Козлов':");
            var kozlovAccounts = bank.GetAccountNumbersByOwner("Козлов");
            foreach (var accNum in kozlovAccounts)
            {
                Console.WriteLine(accNum);
            }

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
