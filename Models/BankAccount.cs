using System;

namespace BankApp.Models
{
    public abstract class BankAccount
    {
        private string _accountNumber;
        private string _owner;
        private decimal _balance;

        public string AccountNumber
        {
            get => _accountNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номер счёта не может быть пустым");
                _accountNumber = value;
            }
        }

        public string Owner
        {
            get => _owner;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Владелец не может быть пустым");
                _owner = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            protected set => _balance = value >= 0 ? value : throw new ArgumentOutOfRangeException("Баланс не может быть отрицательным");
        }

        public BankAccount(string accountNumber, string owner, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public abstract void DisplayInfo();

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Сумма пополнения должна быть положительной");
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Сумма снятия должна быть положительной");
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств на счёте");
            Balance -= amount;
        }
    }
}
