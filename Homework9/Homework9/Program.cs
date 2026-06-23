using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Homework9
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
        }

        static void task1()
        {
            string file = "task1file.json";
            if (!File.Exists(file))
            {
                Console.WriteLine($"{file} does not exist");
                File.WriteAllText(file, "[]");
            }
            else
            {
                Console.WriteLine($"{file} exists");
            }

            Console.Write("Input number of lines: ");
            int count = int.Parse(Console.ReadLine());

            List<string> listwrite = new List<string>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Line {i+1}: ");
                listwrite.Add(Console.ReadLine());
            }

            string write=JsonConvert.SerializeObject(listwrite);

            File.WriteAllText(file, write);

            string read = File.ReadAllText(file);
            List<string> listRead = JsonConvert.DeserializeObject<List<string>>(read);

            if(listRead != null && listRead.Count > 0)
            {
                string lastItem = listRead[listRead.Count - 1];
                Console.WriteLine($"Last item: {lastItem}");
            }
        }

        static void task2()
        {
            string file = "task2file.json";
            if (!File.Exists(file))
            {
                Console.WriteLine($"{file} does not exist");
                File.WriteAllText(file, "");
            }
            else
            {
                Console.WriteLine($"{file} exists");
            }

            Console.Write("Input n: ");
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int r = 1; r <= n; r++)
            {
                string lineText = "";

                for (int c = 1; c <= 9; c++)
                {
                    string line = $"{r} * {c} = {r * c}";
                    if (c > 1)
                    {
                        lineText += " | ";
                    }
                    lineText += line;
                }
                sb.AppendLine(lineText);
            }
            File.WriteAllText(file, sb.ToString());
            Console.WriteLine(File.ReadAllText(file));
        }

        static void task3()
        {
            string file = "task3file.xml";

            Console.Write("Input: ");
            string[] inputParts = Console.ReadLine().Split(' ');

            string text = inputParts[0];
            int n = int.Parse(inputParts[1]);

            int length = text.Length / n;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");

            int index = 0;

            for (int i = 1; i <= n; i++)
            {
                string chunk = "";

                if (i == 1)
                {
                    chunk = text.Substring(index, text.Length-(n-1)*length);
                    index += text.Length - (n-1) * length;
                }
                else
                {
                    chunk = text.Substring(index, length);
                    index += length;
                }

                sb.AppendLine($"  <{chunk}> string {i} </{chunk}>");
            }

            sb.AppendLine("</root>");

            File.WriteAllText(file, sb.ToString());
            Console.WriteLine(File.ReadAllText(file));
        }

        static void task4()
        {
            string file = "task4file.json";
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string read = File.ReadAllText(file);
            BirthdayData data = JsonConvert.DeserializeObject<BirthdayData>(read);

            DateTime current = DateTime.Parse(data.Current);
            DateTime bday = DateTime.Parse(data.Birthday);

            TimeSpan difference = bday - current;
            int daysRemaining = difference.Days;

            Console.WriteLine($"Output: {daysRemaining}");
        }

        static void task5()
        {
            string file = "task5file.json";
            if (!File.Exists(file))
            {
                Console.WriteLine("File not found!");
                return;
            }

            string read = File.ReadAllText(file);
            Cipher data = JsonConvert.DeserializeObject<Cipher>(read);

            string word = data.Word;
            int key = int.Parse(data.Key);

            StringBuilder sb = new StringBuilder();

            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';

                    int x = c - offset;
                    int encryptedX = (x + key) % 26;

                    char encryptedChar = (char)(encryptedX + offset);
                    sb.Append(encryptedChar);
                }
                else
                {
                    sb.Append(c);
                }
            }

            var output = new
            {
                Cipher = sb.ToString()
            };

            string outputJson = JsonConvert.SerializeObject(output);

            Console.WriteLine("Output:");
            Console.WriteLine(outputJson);
        }
    }

    public class BirthdayData
    {
        public string Current { get; set; }
        public string Birthday { get; set; }
    }

    public class Cipher
    {
        public string Word { get; set; }
        public string Key { get; set; } 
    }
}
