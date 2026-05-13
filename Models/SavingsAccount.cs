namespace BankApp.Models
{
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; private set; } = 0.08m; // 8 %

        public SavingsAccount(string accountNumber, string owner, decimal initialBalance)
            : base(accountNumber, owner, initialBalance) { }

        public override void DisplayInfo()
        {
            decimal interestAmount = Balance * InterestRate;
            decimal totalWithInterest = Balance + interestAmount;

            Console.WriteLine($"Сберегательный счёт: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} Руб.");
            Console.WriteLine($"Процентная ставка: {InterestRate:P1}");
            Console.WriteLine($"Проценты: {interestAmount} Руб.");
            Console.WriteLine($"Итого с процентами: {totalWithInterest} Руб.");
        }
    }
}
