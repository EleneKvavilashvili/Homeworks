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

                Console.Write("3) Enrer CVC: ");
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

                Console.WriteLine("Found card!");
                Console.Write("Enter pin: ");
                string pin=Console.ReadLine();

                if (pin != user.CardDetails.PinCode)
                {
                    Console.WriteLine("Please provide correct pin. Your pin is incorrect!");
                    Database.logError($"Incorrect PIN entered for user: {user.LastName}");
                    Console.WriteLine("Press any key to retry...");
                    Console.ReadKey();
                    continue;
                }

                Database.log($"Pin entered. User {user.FirstName} {user.LastName} logged in.");
                
                
            }
        }
    }
}
