using System.Collections.Generic;

namespace final1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<UserAccount> accounts = Database.getKnownAccounts();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter card details:");

                Console.Write("1) Card number: ");
                string cardNumber=Console.ReadLine();

                Console.Write("2) Expiration date(MM/YY): ");
                string expiration=Console.ReadLine();

                Console.Write("3) Enter CVC: ");
                string cvc=Console.ReadLine();

                UserAccount user = accounts.Find(u => u.CardDetails.CardNumber == cardNumber && u.CardDetails.ExpirationDate == expiration && u.CardDetails.CVC == cvc);
                if (user == null)
                {
                    Console.WriteLine("Please enter correct data! Your card is invalid.");
                    Database.logError("Failed login attempt: Invalid card details.");
                    Console.WriteLine("Press any key to retry...");
                    Console.ReadKey();
                    continue;
                }
                Database.log($"Card details entered. Found user: {user.FirstName} {user.LastName}");

                Console.WriteLine("\nFound card!");
                Console.Write("Enter pin: ");
                string pin=Console.ReadLine();

                if (pin != user.CardDetails.PinCode)
                {
                    Console.WriteLine("Please provide correct pin. Your pin is incorrect!");
                    Database.logError($"Incorrect PIN entered for user: {user.LastName}");
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    continue;
                }

                Database.log($"Pin entered. User {user.FirstName} {user.LastName} logged in.");

                ATM(user, accounts);
            }
        }

        static void ATM(UserAccount user, List<UserAccount> accounts)
        {
            Console.WriteLine($"\nHello {user.FirstName} {user.LastName}!");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Get Last 5 Transactions");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Change PIN");
            Console.WriteLine("6. Currency Exchange");
            Console.Write("\nSelect action: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    checkBalance(user);
                    break;
                case "2":
                    withdraw(user);
                    break;
                case "3":
                    lastTransactions(user); 
                    break;
                case "4":
                    deposit(user);
                    break;
                case "5":
                    changePin(user);
                    break;
                case "6":
                    exchange(user);
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    Database.logError("Tried to call invalid action.");
                    break;
            }
            Database.saveTransactions(accounts);
        }

        static void checkBalance(UserAccount user)
        {
            decimal gelBalance = user.TransactionHistory.Sum(t => t.AmountGEL);
            decimal usdBalance = user.TransactionHistory.Sum(t => t.AmountUSD);
            decimal eurBalance = user.TransactionHistory.Sum(t => t.AmountEUR);
            Console.WriteLine("Checking account balance:");
            Console.WriteLine($"GEL: {gelBalance}");
            Console.WriteLine($"USD: {usdBalance}");
            Console.WriteLine($"EUR: {eurBalance}");
            Database.log("Checked balance.");
            addTransaction(user, "Check Balance", 0, 0, 0, 0);
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void withdraw(UserAccount user)
        {
            Console.WriteLine("Withdrawing:");
            Database.log("Trying to withdraw...");
            Console.Write("Select currency: 1)GEL 2)USD or 3)EUR: ");
            string currency = Console.ReadLine();
            if (currency != "1" && currency != "2" && currency != "3")
            {
                Database.logError("Invalid currency option chosen");
                Console.WriteLine("Invalid currency option.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter amount to withdraw: ");
            decimal amount;

            try
            {
                amount = decimal.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Database.logError("Invalid amount entered");
                Console.WriteLine("Error: Invalid amount! Returning to menu...");
                Console.ReadKey();

                return;
            }

            if (amount <= 0)
            {
                Database.logError("Attempted to withdraw a negative amount");
                Console.WriteLine("Error: withdrawal amount must be greater than zero!");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            decimal gelBalance = user.TransactionHistory.Sum(t => t.AmountGEL);
            decimal usdBalance = user.TransactionHistory.Sum(t => t.AmountUSD);
            decimal eurBalance = user.TransactionHistory.Sum(t => t.AmountEUR);

            string curr;
            if (currency == "1" && gelBalance >= amount)
            {
                curr = "GEL";
                gelBalance -= amount;
                addTransaction(user, "Withdraw", amount, -amount, 0, 0);
            }
            else if (currency == "2" && usdBalance >= amount)
            {
                curr = "USD";
                usdBalance -= amount;
                addTransaction(user, "Withdraw", amount, 0, -amount, 0);
            }
            else if (currency == "3" && eurBalance >= amount)
            {
                curr = "EUR";
                eurBalance -= amount;
                addTransaction(user, "Withdraw", amount, 0, 0, -amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
                Database.logError("Tried to withdraw insufficient funds.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();

                return;
            }
            Database.log($"{amount}{curr} withdrawn");
            Console.WriteLine($"{amount}{curr} withdrawn");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void lastTransactions(UserAccount user)
        {
            Console.WriteLine("Checking transactions:");
            List<Transaction> history = user.TransactionHistory;
            if(history.Count < 5)
            {
                foreach (Transaction t in history)
                {
                    Console.WriteLine($"[{t.TransactionDate}] {t.TransactionType} | Details: GEL:{t.AmountGEL} USD:{t.AmountUSD} EUR:{t.AmountEUR}");
                }
            }
            else
            {
                for(int i=history.Count-5; i<history.Count; i++)
                {
                    Transaction t=history[i];
                    Console.WriteLine($"[{t.TransactionDate}] {t.TransactionType} | Details: GEL:{t.AmountGEL} USD:{t.AmountUSD} EUR:{t.AmountEUR}");
                }
            }
            Database.log("Checked last transactions.");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void deposit(UserAccount user)
        {
            Console.WriteLine("Depositing:");
            Database.log("Trying to deposit...");
            Console.Write("Select currency: 1)GEL 2)USD or 3)EUR: ");
            string currency = Console.ReadLine();
            if (currency != "1" && currency != "2" && currency != "3")
            {
                Database.logError("Invalid currency option chosen");
                Console.WriteLine("Invalid currency option.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter amount to deposit: ");
            decimal amount;

            try
            {
                amount = decimal.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Database.logError("Invalid amount entered");
                Console.WriteLine("Error: Invalid amount! Returning to menu...");
                Console.ReadKey();

                return;
            }

            if (amount <= 0)
            {
                Database.logError("Attempted to deposit a negative amount");
                Console.WriteLine("Error: Deposit amount must be greater than zero!");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return; 
            }

            decimal gelBalance = user.TransactionHistory.Sum(t => t.AmountGEL);
            decimal usdBalance = user.TransactionHistory.Sum(t => t.AmountUSD);
            decimal eurBalance = user.TransactionHistory.Sum(t => t.AmountEUR);
            string curr;
            if (currency == "1")
            {
                curr = "GEL";
                gelBalance += amount;
                addTransaction(user, "Deposit", amount, amount, 0, 0);
            }
            else if (currency == "2")
            {
                curr = "USD";
                usdBalance += amount;
                addTransaction(user, "Deposit", amount, 0, amount, 0);
            }
            else
            {
                curr = "EUR";
                eurBalance += amount;
                addTransaction(user, "Deposit", amount, 0, 0, amount);
            }
            Database.log($"{amount}{curr} deposited");
            Console.WriteLine($"{amount}{curr} deposited");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void changePin(UserAccount user)
        {
            Console.WriteLine("Changing PIN:");
            Console.Write("Enter new pin: ");
            string newPin = Console.ReadLine();
            user.CardDetails.PinCode = newPin;
            addTransaction(user, "Change PIN", 0, 0, 0, 0);
            Console.WriteLine("PIN changed");
            Database.log("PIN changed");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        static void exchange(UserAccount user)
        {
            Console.WriteLine("Trying to exchange...");
            Database.log("Trying to exchange currency.");
            Console.Write("Select currency: 1)GEL 2)USD or 3)EUR: ");
            string currency1 = Console.ReadLine();
            if (currency1 != "1" && currency1 != "2" && currency1 != "3")
            {
                Database.logError("Invalid currency option chosen");
                Console.WriteLine("Invalid currency option.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter amount to exchange: ");
            decimal amount;

            try
            {
                amount = decimal.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Database.logError("Invalid amount entered");
                Console.WriteLine("Error: Invalid amount! Returning to menu...");
                Console.ReadKey();

                return;
            }

            if (amount <= 0)
            {
                Database.logError("Attempted to exchange a negative amount");
                Console.WriteLine("Error: Deposit amount must be greater than zero!");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Select currency to exchange into: 1)GEL 2)USD or 3)EUR: ");
            string currency2 = Console.ReadLine();
            if (currency2 != "1" && currency2 != "2" && currency2 != "3" || currency1==currency2)
            {
                Database.logError("Invalid currency option chosen");
                Console.WriteLine("Invalid currency option.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }

            decimal k;

            string curr1;
            string curr2;
            if (currency1 == "1")
            {
                curr1 = "GEL";
                if(currency2 == "2")
                {
                    curr2 = "USD";
                    k = 0.38m;
                    addTransaction(user, "Exchange", amount, -amount, amount * 0.38m, 0);
                }
                else
                {
                    curr2 = "EUR";
                    k = 0.33m;
                    addTransaction(user, "Exchange", amount, -amount, 0, amount * 0.33m);
                }
            }else if(currency1 == "2")
            {
                curr1 = "USD";
                if (currency2 == "1")
                {
                    curr2 = "GEL";
                    k = 2.65m;
                    addTransaction(user, "Exchange", amount, amount*2.65m, -amount, 0);
                }
                else
                {
                    curr2 = "EUR";
                    k = 0.88m;
                    addTransaction(user, "Exchange", amount,0, -amount, amount*0.88m);
                }
            }
            else
            {
                curr1 = "EUR";
                if (currency2 == "1")
                {
                    curr2 = "GEL";
                    k = 3.02m;
                    addTransaction(user, "Exchange", amount, amount * 3.02m, 0, -amount);
                }
                else
                {
                    curr2 = "USD";
                    k = 1.14m;
                    addTransaction(user, "Exchange", amount, 0, amount*1.14m, -amount);
                }
            }

            Console.WriteLine("Exchanged");
            Database.log($"Exchanged {amount}{curr1} to {amount*k}{curr2}");
        }

        static void addTransaction(UserAccount user, string type,  decimal amount, decimal gel, decimal usd, decimal eur)
        {
            Transaction t=new Transaction();
            t.TransactionDate = DateTime.Now.ToString();
            t.TransactionType = type;
            t.Amount = amount;
            t.AmountGEL = gel;
            t.AmountUSD = usd;
            t.AmountEUR = eur;

            user.TransactionHistory.Add(t);
        }
    }
}
