using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework7
{
    internal class Student2
    {
        public string Name { get; set; }

        public Student2(string name)
        {
            Name = name;
        }

        public virtual void Study()
        {
            Console.WriteLine($"{Name} is studying.");
        }
        public virtual void Read()
        {
            Console.WriteLine($"{Name} is reading.");
        }
        public virtual void Write()
        {
            Console.WriteLine($"{Name} is writing.");
        }
        public virtual void Relax()
        {
            Console.WriteLine($"{Name} is relaxing.");
        }
    }
}
