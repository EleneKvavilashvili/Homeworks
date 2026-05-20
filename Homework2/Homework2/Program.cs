namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("Elene Kvavilashvili");
            Console.Write("Please enter input you wish to print: ");
            string input = Console.ReadLine();
            Console.WriteLine("You entered: " + input);
        }
    }
}
