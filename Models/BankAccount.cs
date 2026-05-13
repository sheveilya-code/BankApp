namespace BankApp.Models
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; }
        public string Owner { get; }
        protected decimal Balance { get; set; }

        public BankAccount(string accountNumber, string owner, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public abstract void DisplayInfo();
    }
}
