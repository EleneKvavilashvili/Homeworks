using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    internal abstract class FileWorker
    {
        public int MaxFileSize { get; set; }

        public abstract string FileExtension { get; }

        protected FileWorker(int maxFileSize)
        {
            MaxFileSize = maxFileSize;
        }

        public abstract void Read();
        public abstract void Write();
        public abstract void Edit();
        public abstract void Delete();

    }
}
