using System.ComponentModel;
using System.Linq;

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem1

            /*Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine($"Enter {n} elements for the array: ");

            int oddCount = 0;
            int evenCount = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
                if (array[i] % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            int[] odds = new int[oddCount];
            int[] evens = new int[evenCount];

            int oddIndex = 0;
            int evenIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evens[evenIndex] = array[i];
                    evenIndex++;
                }
                else
                {
                    odds[oddIndex] = array[i];
                    oddIndex++;
                }
            }

            Console.WriteLine("\nEvens are: ");
            foreach (int i in evens)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\nOdds are: ");
            foreach (int i in odds)
            {
                Console.Write($"{i} ");
            }*/

            #endregion

            #region Problem2

            /*Dictionary<string, string> contacts = new Dictionary<string, string>();
            while (true)
            {
                Console.WriteLine("\nYou can 1)add, 2)delete, 3)update Contacts, 4)see all contacts, 5)end program.");
                Console.Write("Make your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact(contacts);
                        break;
                    case "2":
                        DeleteContact(contacts);
                        break;
                    case "3":
                        UpdateContact(contacts);
                        break;
                    case "4":
                        PrintContacts(contacts);
                        break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice. Try again: ");
                        break;
                }
            }*/

            #endregion

            #region problem 3

            /*Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            Console.WriteLine($"Enter {n} numbers (separated by space):");
            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(inputs[i]);
            }

            var groups = numbers.GroupBy(key => key).OrderBy(values => values.Key);

            foreach (var group in groups)
            {
                int num = group.Key;
                int count = group.Count();
                int sum = group.Sum();
                Console.WriteLine($"{num} appears {count} times sum {sum}");
            }*/

            #endregion

            /*string word = Console.ReadLine();
            for(int i=0; i<word.Length/2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    Console.WriteLine("Not a palindrome");
                    return;
                }
            }
            Console.WriteLine("Is Palindrome");*/

            /*int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for(int i=0; i < n; i++)
            {
                arr[i]=int.Parse(Console.ReadLine());
            }
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
            }*/

            Console.Write("Enter array size: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element N{i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                int temp = arr[i];
                int j = i - 1;

                while(j>=0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = temp;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }

        #region problem2 functions
        static void AddContact(Dictionary<string, string> contacts)
        {
            Console.WriteLine("\nAdding new contact: ");
            Console.Write("Enter Name: ");
            string name=Console.ReadLine();

            if (contacts.ContainsKey(name))
            {
                Console.WriteLine("Contact already exists.");
            }
            else
            {
                Console.Write("Enter Number: ");
                string number = Console.ReadLine();
                contacts.Add(name, number);
                Console.WriteLine("Contact added.");
            }
        }
        static void DeleteContact(Dictionary<string, string> contacts)
        {
            Console.WriteLine("\nDeleting contact: ");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            if (!contacts.ContainsKey(name))
            {
                Console.WriteLine("Contact does not exist.");
            }
            else
            {
                contacts.Remove(name);
                Console.WriteLine("Contact deleted.");
            }
        }
        static void UpdateContact(Dictionary<string, string> contacts)
        {
            Console.WriteLine("\nUpdating contact: ");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            if (!contacts.ContainsKey(name))
            {
                Console.WriteLine("Contact does not exist.");
            }
            else
            {
                Console.Write("Enter new Number: ");
                contacts[name] = Console.ReadLine();
                Console.WriteLine("Contact updated.");
            }
        }
        static void PrintContacts(Dictionary<string, string> contacts)
        {
            if (contacts.Count() == 0)
            {
                Console.WriteLine("\nContacts are empty!");
            }
            else
            {
                Console.WriteLine("\nAll contacts: ");
                foreach (string key in contacts.Keys)
                {
                    Console.WriteLine($"{key} : {contacts[key]}");
                }
            }
        }

        #endregion
    }
}

