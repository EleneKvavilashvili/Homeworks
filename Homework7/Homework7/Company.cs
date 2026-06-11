using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class Company
    {
        public bool IsLocal { get; set; }
        public int TaxRate => IsLocal ? 18 : 5;

        public Company(string type)
        {
            IsLocal = type.ToLower() == "local";
        }

        public double CalculateTax(double totalSalary)
        {
            return totalSalary * TaxRate / 100;
        }
    }

}
