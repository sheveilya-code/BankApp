using BankApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApp.Services
{
    public class Bank
    {
        private List<BankAccount> _accounts = new();

        public void AddAccount(BankAccount account)
        {
            _accounts.Add(account);
            Console.WriteLine($"Счёт {account.AccountNumber} добавлен в банк");
        }

        public BankAccount FindAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
        }

        public void DisplayAllAccounts()
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("В банке нет открытых счетов");
                return;
            }

            Console.WriteLine("=== Все счета в банке ===");
            foreach (var account in _accounts)
            {
                account.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}
