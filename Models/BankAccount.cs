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
                    throw new ArgumentException("Номер счёта не может быть пустым.");

                _accountNumber = value;
            }
        }

        public string Owner
        {
            get => _owner;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя владельца не может быть пустым.");

                _owner = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            protected set => _balance = value;
        }

        protected BankAccount(string accountNumber, string owner, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Owner = owner;

            if (initialBalance < 0)
                throw new ArgumentException("Начальный баланс не может быть отрицательным.");

            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма пополнения должна быть больше нуля.");

            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма снятия должна быть больше нуля.");

            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств на счёте.");

            Balance -= amount;
        }

        public abstract void DisplayInfo();
    }
}