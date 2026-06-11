using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int EnrollmentYear { get; set; }

        private readonly string[] subjects = { "Math", "Chem", "ENG", "Hist" };
        public Student(string name, int age, int enrollmentYear)
        {
            Name = name;
            Age = age;
            EnrollmentYear = enrollmentYear;
        }
        public string GetRandomSubject()
        {
            Random rand = new Random();
            int index = rand.Next(subjects.Length);
            return subjects[index];
        }
        public int YearsLeftToGraduate()
        {
            int currentYear = 2026;
            int yearsStudied = currentYear - EnrollmentYear;
            int yearsLeft = 4 - yearsStudied;

            return yearsLeft < 0 ? 0 : yearsLeft;
        }
    }
}
