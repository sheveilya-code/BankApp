using BankApp.Models;

namespace BankApp.Services
{
    public class Bank
    {
        private readonly List<BankAccount> _accounts = new();

        public void AddAccount(BankAccount account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account), "Счёт не может быть пуст.");

            if (_accounts.Any(a => a.AccountNumber == account.AccountNumber))
                throw new InvalidOperationException("Счёт с таким номером уже существует.");

            _accounts.Add(account);
        }

        public BankAccount? FindAccountByNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _accounts;
        }

        public List<SavingsAccount> GetSavingsAccounts()
        {
            return _accounts.OfType<SavingsAccount>().ToList();
        }

        public void DisplayAllAccounts()
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("Счета отсутствуют.");
                Console.WriteLine();
                return;
            }

            foreach (var account in _accounts)
            {
                account.DisplayInfo();
            }
        }
    }
}