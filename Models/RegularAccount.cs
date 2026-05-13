namespace BankApp.Models
{
    public class RegularAccount : BankAccount
    {
        public RegularAccount(string accountNumber, string owner, decimal initialBalance)
            : base(accountNumber, owner, initialBalance)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("=== Обычный счёт ===");
            Console.WriteLine($"Номер счёта: {AccountNumber}");
            Console.WriteLine($"Владелец: {Owner}");
            Console.WriteLine($"Баланс: {Balance} Руб.");
            Console.WriteLine();
        }
    }
}