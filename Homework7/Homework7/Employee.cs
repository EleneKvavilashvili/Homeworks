using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int[] WeeklyHours { get; set; }


        public Employee(string name, string surname, int age, string position, int[] hours)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Position = position.ToLower();
            WeeklyHours = hours;
        }

        public double CalculateWeeklySalary()
        {
            double hourlyRate = 0;
            switch (Position)
            {
                case "manager":
                    hourlyRate = 40;
                    break;
                case "developer":
                    hourlyRate = 30;
                    break;
                case "tester":
                    hourlyRate = 20;
                    break;
                default:
                    hourlyRate = 10;
                    break;
            }

            double totalSalary = 0;

            int totalHoursWorked = 0;
            for(int i=0; i<WeeklyHours.Length; i++)
            {
                totalHoursWorked += WeeklyHours[i];
            }

            for (int i = 0; i < WeeklyHours.Length; i++)
            {
                int hours=WeeklyHours[i];
                bool isWeekend;
                if (i == 5 || i == 6)
                {
                    isWeekend = true;
                }
                else
                {
                    isWeekend=false;
                }

                int normal=Math.Min(hours, 8);
                int over=Math.Max(0, hours-8);

                double dailySalary = (normal * hourlyRate) + (over * (hourlyRate + 5));

                if (isWeekend)
                {
                    dailySalary *= 2;
                }

                totalSalary += dailySalary;
            }

            if (totalHoursWorked > 50)
            {
                totalSalary += totalSalary * 0.2;
            }

            return totalSalary;
        }
    }
}
