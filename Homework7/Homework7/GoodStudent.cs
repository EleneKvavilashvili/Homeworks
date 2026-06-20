using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class GoodStudent : Student2
    {
        public GoodStudent(string name) : base(name)
        {

        }
        public override void Study()
        {
            Console.WriteLine($"{Name} is always studying.");
        }
        public override void Read()
        {
            Console.WriteLine($"{Name} is reading literature.");
        }
        public override void Write()
        {
            Console.WriteLine($"{Name} is writing an essay.");
        }
        public override void Relax()
        {
            Console.WriteLine($"{Name} is barely relaxing.");
        }
    }
}
