namespace BankApp.Models
{
    public class CreditAccount : BankAccount
    {
        private decimal _creditLimit;

        public decimal CreditLimit
        {
            get => _creditLimit;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Кредитный лимит не может быть отрицательным.");

                _creditLimit = value;
            }
        }

        public CreditAccount(string accountNumber, string owner, decimal initialBalance, decimal creditLimit)
            : base(accountNumber, owner, initialBalance)
        {
            CreditLimit = creditLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма снятия должна быть больше нуля.");

            if (Balance - amount < -CreditLimit)
                throw new InvalidOperationException("Превышен кредитный лимит.");

            Balance -= amount;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== Кредитный счёт ===");
            Console.WriteLine($"Номер счёта: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} Руб.");
            Console.WriteLine($"Кредитный лимит: {CreditLimit} Руб.");
            Console.WriteLine($"Доступно с учётом кредита: {(Balance + CreditLimit)} Руб.");
            Console.WriteLine();
        }
    }
}