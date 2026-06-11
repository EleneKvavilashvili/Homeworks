using System;

namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Problem? (1, 2 ან 3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "3":
                    //RunTask3();
                    break;
                default:
                    Console.WriteLine("INVALID");
                    break;
            }
        }

        static void RunTask1()
        {
            Console.Write("Company type (foreign/local): ");
            string type = Console.ReadLine();
            Company company = new Company(type);

            Console.Write("Name: "); 
            string name = Console.ReadLine();

            Console.Write("Surname: "); 
            string surname = Console.ReadLine();

            Console.Write("Age: "); 
            int age = int.Parse(Console.ReadLine());

            Console.Write("Position? (Manager, Developer, tester, other): "); 
            string position = Console.ReadLine();

            Console.Write("Enter hours worked this week (separated by , ): ");
            int[] hours = Console.ReadLine().Split(',').Select(x => int.Parse(x.Trim())).ToArray();

            Employee employee = new Employee(name, surname, age, position, hours);

            double totalSalary = employee.CalculateWeeklySalary();
            double tax = company.CalculateTax(totalSalary);

            Console.WriteLine($"Total salary of {name} {surname} is {totalSalary}.");
            Console.WriteLine($"Tax paid is {tax}.");
        }

        static void RunTask2()
        {
            Student student = new Student("elene", 20, 2024);
            Teacher teacher = new Teacher("gurami", true);

            Console.WriteLine($"Years left: {student.YearsLeftToGraduate()} years.");
            string chosenSubject = student.GetRandomSubject();
            teacher.CheckSubject(chosenSubject);
        }
    }
}
