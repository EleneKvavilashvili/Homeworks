using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    internal class TxtFileWorker : FileWorker
    {
        public override string FileExtension
        {
            get
            {
                return "txt";
            }
        }

        public TxtFileWorker(int maxFileSize) : base(maxFileSize) { }

        public override void Write()
        {
            Console.WriteLine($"I Can write to {FileExtension} file with max storage {MaxFileSize}");
        }

        public override void Read()
        {
            Console.WriteLine($"I Can read from {FileExtension} file with max storage {MaxFileSize}");
        }

        public override void Delete()
        {
            Console.WriteLine($"I Can delete from {FileExtension} file with max storage {MaxFileSize}");
        }

        public override void Edit()
        {
            Console.WriteLine($"I Can edit {FileExtension} file with max storage {MaxFileSize}");
        }
    }
}
