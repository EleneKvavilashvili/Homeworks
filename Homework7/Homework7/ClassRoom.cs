using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class ClassRoom
    {
        private List<Student2> _students;

        public ClassRoom(List<Student2> students)
        {
            _students = students;
        }

        public void PrintAllStudentActivities()
        {
            Console.WriteLine("Describing all students in our classroom:\n");
            foreach (var student in _students)
            {
                Console.WriteLine($"{student.Name}: ");
                student.Study();
                student.Read();
                student.Write();
                student.Relax();
                Console.WriteLine(); // ცარიელი ხაზი გამოყოფისთვის
            }
        }
    }
}
