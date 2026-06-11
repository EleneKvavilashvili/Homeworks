using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class Teacher
    {
        public string Name { get; set; }
        public bool IsCertified { get; set; }

        public Teacher(string name, bool isCertified)
        {
            Name = name;
            IsCertified = isCertified;
        }

        public void CheckSubject(string subject)
        {
            Random rand = new Random();

            switch (subject)
            {
                case "Math":
                    int num1 = rand.Next(1, 100);
                    int num2 = rand.Next(1, 100);
                    Console.WriteLine($"Sum: {num1} + {num2} = {num1 + num2}");
                    break;

                case "Chem":
                    string[] formulas = { "H2O", "CO2", "NaCl" };
                    Console.WriteLine($"{formulas[rand.Next(formulas.Length)]}");
                    break;

                case "ENG":
                    Console.WriteLine("Hello world");
                    break;

                default:
                    Console.WriteLine($"I am not competent in: {subject}");
                    break;
            }
        }
    }
}
