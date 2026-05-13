using BankApp.Models;
using BankApp.Services;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                Console.Write("Выберите пункт меню: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            CreateAccount(bank);
                            break;
                        case "2":
                            DepositToAccount(bank);
                            break;
                        case "3":
                            WithdrawFromAccount(bank);
                            break;
                        case "4":
                            ShowAccountInfo(bank);
                            break;
                        case "5":
                            bank.DisplayAllAccounts();
                            break;
                        case "6":
                            exit = true;
                            Console.WriteLine("Выход из программы...");
                            break;
                        default:
                            Console.WriteLine("Некорректный пункт меню.");
                            Console.WriteLine();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.WriteLine();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ошибка операции: {ex.Message}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("====== BankApp ======");
            Console.WriteLine("1. Создать счёт");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать информацию о счёте");
            Console.WriteLine("5. Показать все счета");
            Console.WriteLine("6. Выйти");
            Console.WriteLine();
        }

        static void CreateAccount(Bank bank)
        {
            Console.WriteLine("Выберите тип счёта:");
            Console.WriteLine("1. Обычный счёт");
            Console.WriteLine("2. Сберегательный счёт");
            Console.WriteLine("3. Кредитный счёт");
            Console.Write("Ваш выбор: ");
            string? typeChoice = Console.ReadLine();

            Console.Write("Введите номер счёта: ");
            string? accountNumber = Console.ReadLine();

            Console.Write("Введите имя владельца: ");
            string? owner = Console.ReadLine();

            decimal initialBalance = ReadDecimal("Введите начальный баланс: ");

            BankAccount account;

            switch (typeChoice)
            {
                case "1":
                    account = new RegularAccount(accountNumber!, owner!, initialBalance);
                    break;

                case "2":
                    int interestPercent = ReadInt("Введите процентную ставку в процентах (например, 5 для 5%): ");

                    if (interestPercent < 0)
                    {
                        Console.WriteLine("Процентная ставка не может быть отрицательной.");
                        Console.WriteLine();
                        return;
                    }

                    decimal interestRate = interestPercent / 100m;
                    account = new SavingsAccount(accountNumber!, owner!, initialBalance, interestRate);
                    break;

                case "3":
                    decimal creditLimit = ReadDecimal("Введите кредитный лимит: ");
                    account = new CreditAccount(accountNumber!, owner!, initialBalance, creditLimit);
                    break;

                default:
                    Console.WriteLine("Некорректный тип счёта.");
                    Console.WriteLine();
                    return;
            }

            bank.AddAccount(account);
            Console.WriteLine("Счёт успешно создан.");
            Console.WriteLine();
        }

        static void DepositToAccount(Bank bank)
        {
            Console.Write("Введите номер счёта: ");
            string? accountNumber = Console.ReadLine();

            BankAccount? account = bank.FindAccountByNumber(accountNumber!);
            if (account == null)
            {
                Console.WriteLine("Счёт не найден.");
                Console.WriteLine();
                return;
            }

            decimal amount = ReadDecimal("Введите сумму пополнения: ");
            account.Deposit(amount);

            Console.WriteLine("Счёт успешно пополнен.");
            Console.WriteLine();
        }

        static void WithdrawFromAccount(Bank bank)
        {
            Console.Write("Введите номер счёта: ");
            string? accountNumber = Console.ReadLine();

            BankAccount? account = bank.FindAccountByNumber(accountNumber!);
            if (account == null)
            {
                Console.WriteLine("Счёт не найден.");
                Console.WriteLine();
                return;
            }

            decimal amount = ReadDecimal("Введите сумму снятия: ");
            account.Withdraw(amount);

            Console.WriteLine("Операция выполнена успешно.");
            Console.WriteLine();
        }

        static void ShowAccountInfo(Bank bank)
        {
            Console.Write("Введите номер счёта: ");
            string? accountNumber = Console.ReadLine();

            BankAccount? account = bank.FindAccountByNumber(accountNumber!);
            if (account == null)
            {
                Console.WriteLine("Счёт не найден.");
                Console.WriteLine();
                return;
            }

            account.DisplayInfo();
        }

        static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal value))
                {
                    return value;
                }

                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Некорректный ввод. Введите целое число.");
            }
        }
    }
}