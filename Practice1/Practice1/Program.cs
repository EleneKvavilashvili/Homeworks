namespace Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
            //task4();
            //task5();
            //task6();
            //task7();
            //task8();
            //task9();
        }

        static void task1()
        {
            Console.Write("Enter string: ");
            string str= Console.ReadLine();

            Dictionary<char, int> map= new Dictionary<char, int>();
            for(int i=0; i<str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                {
                    map[str[i]]++;
                }
                else
                {
                    map[str[i]] = 1;
                }
            }

            int index = -1;
            for(int i=0; i<str.Length; i++)
            {
                if (map[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine($"The index of the first unique character in your string is {index}.");
        }

        static void task2()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            string[] parts = str.Split(" ");

            int count = 0;
            for(int i=0; i<parts.Length; i++)
            {
                if(parts[i].Length != 0)
                {
                    count++;
                }
            }
            Console.WriteLine($"Your string contains {count}.");
        }

        static void task3()
        {

        }

        static void task4()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            if (str.Length <= 1)
            {
                Console.WriteLine("False...");
                return;
            }

            for(int l=1; l<=str.Length/2; l++)
            {
                if (str.Length % l == 0)
                {
                    string sub=str.Substring(0, l);
                    string duplicate = sub;
                    while (duplicate.Length != str.Length)
                    {
                        duplicate += sub;
                    }

                    if (duplicate == str)
                    {
                        Console.WriteLine("True...");
                        return;
                    }
                }
            }

            Console.WriteLine("False...");
        }

        static void task5()
        {
            Console.Write("Enter string1: ");
            string str1 = Console.ReadLine();
            Console.Write("Enter string2: ");
            string str2 = Console.ReadLine();

            if(str1.Length != str2.Length)
            {
                Console.WriteLine("Not anagrams...");
                return;
            }

            //v1
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < str1.Length; i++)
            {
                if (map.ContainsKey(str1[i]))
                {
                    map[str1[i]]++;
                }
                else
                {
                    map[str1[i]] = 1;
                }
            }

            for (int i = 0; i < str2.Length; i++)
            {
                if (map.ContainsKey(str2[i]))
                {
                    if (map[str2[i]] == 0)
                    {
                        Console.WriteLine("Not anagrams...");
                        return;
                    }
                    else
                    {
                        map[str2[i]]--;
                    }
                }
                else
                {
                    Console.WriteLine("Not anagrams...");
                    return;
                }
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (map[str1[i]] > 0)
                {
                    Console.WriteLine("Not anagrams...");
                    return;
                }
            }

            Console.WriteLine("Anagrams...");


            //v2
            char[] array1 = str1.ToCharArray();
            char[] array2 = str2.ToCharArray();
            Array.Sort(array1);
            Array.Sort(array2);

            for(int i=0; i<str1.Length; i++)
            {
                if(array1[i] != array2[i])
                {
                    Console.WriteLine("Not anagrams...");
                    return;
                }
            }
            Console.WriteLine("Anagrams...");
            
        }

        static void task6()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            int left = 0;
            int right = str.Length - 1;
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] array = str.ToCharArray();

            while (left < right)
            {
                while (left < right && !vowels.Contains(str[left]))
                {
                    left++;
                }

                while (left < right && !vowels.Contains(str[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    char temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;

                    left++;
                    right--;
                }
            }
            string newstr = "";
            for(int i = 0; i < array.Length; i++)
            {
                newstr += array[i];
            }
            Console.WriteLine(newstr);
        }

        static void task7()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            if (str == "")
            {
                Console.WriteLine("No palindrome");
                return;
            }

            string longest = "";

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    int length = j - i + 1;
                    string substring = str.Substring(i, length);

                    if (IsPalindrome(substring) && substring.Length > longest.Length)
                    {
                        longest = substring;
                    }
                }
            }
            if (longest == "")
            {
                Console.WriteLine("No palindrome");
            }
            else
            {
                Console.WriteLine($"Longest palindrome is: {longest}");
            }
        }
        static bool IsPalindrome(string sub)
        {
            int left = 0;
            int right = sub.Length - 1;

            while (left < right)
            {
                if (sub[left] != sub[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        static void task8()
        {
            int[] nums = { 1, 2, 2, 3, 3, 3 };

            Dictionary<int, int> counts = new Dictionary<int, int>();
            int mostFrequent = nums[0];
            int maxCount = 0;

            foreach (int num in nums)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }

                if (counts[num] > maxCount)
                {
                    maxCount = counts[num];
                    mostFrequent = num;
                }
            }

            Console.WriteLine($"Most frequent is {mostFrequent} with frequency {maxCount}");
        }

        static void task9()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            string[] parts = str.Split(" ");
            int count = 0;
            int sum = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length != 0)
                {
                    count++;
                    sum += parts[i].Length;
                }
            }
            int average = sum / count;
            if (sum % count != 0)
            {
                average++;
            }
            Console.WriteLine($"Average length is {sum}/{count}={average}.");
        }
    }
}
