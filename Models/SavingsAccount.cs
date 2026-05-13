namespace BankApp.Models
{
    public class SavingsAccount : BankAccount
    {
        private decimal _interestRate;

        public decimal InterestRate
        {
            get => _interestRate;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Процентная ставка не может быть отрицательной.");

                _interestRate = value;
            }
        }

        public SavingsAccount(string accountNumber, string owner, decimal initialBalance, decimal interestRate = 0.05m)
            : base(accountNumber, owner, initialBalance)
        {
            InterestRate = interestRate;
        }

        public decimal GetCalculatedBalance()
        {
            return Balance + (Balance * InterestRate);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== Сберегательный счёт ===");
            Console.WriteLine($"Номер счёта: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Текущий баланс: {Balance}  Руб.");
            Console.WriteLine($"Процентная ставка: {InterestRate * 100}%");
            Console.WriteLine($"Расчётный баланс с процентами: {GetCalculatedBalance()}  Руб.");
            Console.WriteLine();
        }
    }
}