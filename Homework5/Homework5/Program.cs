namespace Homework5
{
    using System;
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            #region problem1

            //side of the outer square is 2*r, and side of the inner square is sqrt(2)*r
            //consequently, the areas are: outer square: 4r^2 and inner square: 2r^2
            //In conclusion, the difference in the areas is always 2r^2

            /*Console.Write("Enter the radius of the circle(double): ");
            double r = double.Parse(Console.ReadLine());

            Console.WriteLine($"Area of the outer circle is {4 * r * r} and the area of the inner circle is {2 * r * r};");
            Console.WriteLine($"So the difference between the inner and outer circle areas is {2 * r * r}.");*/

            #endregion

            #region problem2

            /*Console.Write("Enter results (separated by a space): ");
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("Not jackpot.");
                return;
            }
            string[] slotMachine = input.Split(' ').ToArray();
            if (slotMachine.All(x=>x == slotMachine[0]))
            {
                Console.WriteLine("Jackpot!");
            }
            else
            {
                Console.WriteLine("Not jackpot.");
            }*/

            #endregion

            #region problem3

            /*Console.Write("Amount of wins: ");
            int wins=int.Parse(Console.ReadLine());

            Console.Write("Amount of draws: ");
            int draws = int.Parse(Console.ReadLine());

            Console.Write("Amount of loses: ");
            int loses = int.Parse(Console.ReadLine());

            int score = wins * 3 + draws;
            Console.WriteLine($"\nYour team has collected a total of {score} points.");*/

            #endregion

            #region problem4

            /*Console.Write("Enter amount of hours worked on a given day, separated by , : ");
            string input = Console.ReadLine();

            int[] hours = input.Split(',').Select(x => int.Parse(x)).ToArray();
            if (hours.Length != 7)
            {
                Console.WriteLine("incorrect amount of days!");
                return;
            }

            int salary = 0;

            for (int i = 0; i < hours.Length; i++)
            {
                int normal;
                int over;
                int daySalary;

                if (hours[i] > 8)
                {
                    normal = 8;
                    over = hours[i] - 8;
                }
                else
                {
                    normal = hours[i];
                    over = 0;
                }

                daySalary = normal * 10 + over * 15;
                if (i == 5 || i == 6)
                {
                    daySalary *= 2;
                }

                salary += daySalary;
            }

            Console.WriteLine($"\nYour salary of the week is {salary}.");*/

            #endregion

            #region problem5

            /*Console.Write("Enter results reached on a given day, separated by , : ");
            string input = Console.ReadLine();

            int[] results = input.Split(',').Select(x => int.Parse(x)).ToArray();

            int progress = 0;

            for(int i=1; i<results.Length; i++)
            {
                if (results[i] > results[i - 1])
                {
                    progress++;
                }
            }

            Console.WriteLine($"\nYou made progress on {progress} days.");*/

            #endregion

            #region problem6

            /*string[] words = { "Hello", "World", "Programming", "communication" };
            int n = 5;

            var result = words.Where(w => w.Length == n).ToList();

            if(result.Count == 0 )
            {
                Console.WriteLine("No results found");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }*/

            #endregion
        }
    }
}
