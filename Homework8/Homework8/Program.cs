namespace Homework8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            task1();
            Console.WriteLine("\n");
            task2();
        }

        static void task1()
        {
            FileWorker worker = new TxtFileWorker(128);
            worker.Write();
            worker.Read();
            worker.Delete();
            worker.Edit();
        }

        static void task2()
        {
            int months = 12;
            double monthlyPayment = 100;

            IFinanceOperations bank = new Bank();
            if (bank.CheckUserHistory())
            {
                Console.WriteLine("Bank Accepted!");
                double bankTotalB = bank.CalculateLoanPercent(months, monthlyPayment);
                Console.WriteLine($"Total ${bankTotalB}");
            }
            else
            {
                Console.WriteLine("Not accepted!");
            }

            IFinanceOperations mfo = new MicroFinance();
            Console.WriteLine("MF Accepted!");
            double bankTotalM = bank.CalculateLoanPercent(months, monthlyPayment);
            Console.WriteLine($"Total ${bankTotalM}");
        }
    }
}
