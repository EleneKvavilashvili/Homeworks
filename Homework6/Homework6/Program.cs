namespace Homework6
{
    using System.Linq;
    internal class Program
    {
        static void Main(string[] args)
        {
            #region p1

            /*Console.Write("Enter min: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Enter max: ");
            int max = int.Parse(Console.ReadLine());

            Console.Write("Enter power: ");
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nOutput: {countPowersInInterval(min, max, power)}\n");*/

            #endregion

            #region p2

            /*Console.Write("Input: ");
            int pairs = int.Parse(Console.ReadLine());

            Console.WriteLine($"Found {pairs} pairs.");*/

            #endregion

            #region p3

            /*Console.Write("Enter string N1: ");
            string s1=Console.ReadLine();

            Console.Write("Enter string N2: ");
            string s2 = Console.ReadLine();

            Console.WriteLine($"Longest suffix is {findLongestSuffix(s1, s2)}.");*/

            #endregion

            #region p4

            /*processList(new List<int> { 5, 5 });
            processList(new List<string> { "test", "random", "programming", "word" });
            processList(new List<bool> { true, false, true, false, true, false, false });
            Console.WriteLine();*/

            #endregion

            #region p5

            /*Console.Write("Enter number: ");
            int n=int.Parse(Console.ReadLine());
            printDigits(n);*/

            #endregion

            #region p6

            /*Console.Write("Enter numbers separated by , : ");
            string input=Console.ReadLine();

            int[] nums = input.Split(',').Select(x => int.Parse(x.Trim())).ToArray();
            if (containsDuplicate(nums))
            {
                Console.WriteLine("Contains duplicates.");
            }
            else
            {
                Console.WriteLine("Doesn't contain duplicates.");
            }*/

            #endregion
        }

        static int countPowersInInterval(int min, int max, int power)
        {
            int count = 0;

            for (int i = (int)Math.Ceiling(Math.Pow(min, 1.0 / power)); ; i++)
            {
                double pow = Math.Pow(i, power);

                if (pow >= min && pow <= max)
                {
                    count++;
                }

                if (pow > max)
                {
                    break;
                }
            }

            return count;
        }

        static int countSockPairs(string socks)
        {
            Dictionary<char, int> socksCount=new Dictionary<char, int>();
            foreach(char sock in socks){
                if (socksCount.ContainsKey(sock))
                {
                    socksCount[sock]++;
                }
                else
                {
                    socksCount[sock] = 1;
                }
            }

            int pairs = 0;

            foreach(int count in socksCount.Values)
            {
                pairs += count / 2;
            }

            return pairs;
        }

        static string findLongestSuffix(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return string.Empty;
            }

            int i = s1.Length - 1;
            int j = s2.Length - 1;
            string suffix = "";

            while (i >= 0 && j >= 0 && s1[i] == s2[j])
            {
                suffix = s1[i] + suffix;
                i--;
                j--;
            }

            return suffix;  
        }

        static void processList<T>(List<T> list)
        {
            if (list == null || list.Count == 0) return;

            if (list is List<string> stringList)
            {
                foreach (var str in stringList)
                {
                    Console.Write($"{str.ToUpper()} ");
                }
            }
            else if (list is List<int> intList)
            {
                int sum = 0;

                for(int i=0; i<intList.Count; i++)
                {
                    sum += intList[i];
                }

                Console.WriteLine($"Sum: {sum}");
            }
            else if (list is List<bool> boolList)
            {
                var first = boolList[0];
                var last = boolList[boolList.Count - 1];
                var middle = boolList[boolList.Count / 2];

                Console.WriteLine($"first Element is {first}");
                Console.WriteLine($"Last Element is {last}");
                Console.WriteLine($"Middle Element is {middle}");
            }
        }

        static void printDigits(int n)
        {
            if (n < 10)
            {
                Console.Write(n);
                return;
            }

            printDigits(n/10);

            Console.Write($" - {n % 10}");
        }

        static bool containsDuplicate(int[] nums)
        {
            HashSet<int> numbers = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!numbers.Add(num))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
