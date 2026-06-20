using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class LazyStudent : Student2
    {
        public LazyStudent(string name) : base(name) { 
        }

        public override void Study()
        {
            Console.WriteLine($"{Name} is not studying at all.");
        }
        public override void Read()
        {
            Console.WriteLine($"{Name} is not reading anything.");
        }
        public override void Write()
        {
            Console.WriteLine($"{Name} is doodling .");
        }
        public override void Relax()
        {
            Console.WriteLine($"{Name} is always relaxing.");
        }
    }
}
