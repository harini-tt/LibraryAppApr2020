using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*^*^* Welcome to my Library! *^*^*");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Checkout books");
                Console.WriteLine("3. Return books");
                Console.WriteLine("4. View all accounts");
                Console.WriteLine("5. Account history");

                var lobbyoption = Console.ReadLine();
                switch (lobbyoption)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the library!");
                        return;
                    case "1":
                        Console.Write("Member Name: ");
                        var memberName = Console.ReadLine();
                        Console.Write("User Name: ");
                        var userName = Console.ReadLine();

                        Console.WriteLine("Type of Account: ");
                        var accountTypes = Enum.GetNames(typeof(TypesofAccounts));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = Enum.Parse<TypesofAccounts>(Console.ReadLine());

                        Console.WriteLine("Pin Number: ");
                        var pinNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        Console.WriteLine("Phone Number: ");
                        var phoneNumber = Convert.ToInt32(Console.ReadLine());

                        var account = LibraryAcc.CreateAccount(memberName, userName, accountType, pinNumber, emailAddress, phoneNumber);
                        Console.WriteLine($"Member Name: {account.MemberName}, User Name: {account.UserName}, Account Type: {account.AccountType}, Pin Number: {account.PinNumber}, Email Address: {account.EmailAddress}, Phone Number: {account.PhoneNumber}");

                        break;

                    case "2":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number: ");
                            var acctNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("How many books do you want to checkout? ");
                            var amt = Convert.ToInt32(Console.Read());

                            LibraryAcc.Checkout(acctNumber, amt);
                            Console.WriteLine($"You have successfully checked out your books.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong. Please try again!");
                        }
                        break;

                    case "3":
                        PrintAllAccounts();
                        try
                        {
                            Console.Write("Account Number: ");
                            var accountNumb = Convert.ToInt32(Console.ReadLine());
                            Console.Write("How many books do you want to return? ");
                            var amount = Convert.ToInt32(Console.Read());

                            LibraryAcc.Return(accountNumb, amount);
                            Console.WriteLine($"You have successfully returned your books.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input is invalid. Please try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong. Please try again!");
                        }
                        break;

                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.Read());

                        var accountHistory = LibraryAcc.GetAccountHistory(accountNumber);
                        foreach (var transaction in accountHistory)
                        {
                            Console.WriteLine($"Transaction Date: {transaction.TransactionDate}, Transaction Amount: {transaction.Amount}, Transaction Number: {transaction.AccountNumber}");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid choice please try again.");
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Phone Number: ");
            var phoneNumber = Convert.ToInt32(Console.ReadLine());
            var accounts = LibraryAcc.GetAccounts(phoneNumber);
            foreach (var a in accounts)
            {
                Console.WriteLine($"Account Number: {a.AccountNumber}, Member Name: {a.MemberName}, User Name: {a.UserName}, Account Type: {a.AccountType}, Pin Number: {a.PinNumber}, Email Address: {a.EmailAddress}, Phone Number: {a.PhoneNumber}");
            }
        }
    }
}