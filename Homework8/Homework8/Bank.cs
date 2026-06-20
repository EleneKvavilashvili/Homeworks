using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    internal class Bank : IFinanceOperations
    {
        public bool CheckUserHistory()
        {
            Random random = new Random();
            bool[] choices = { true, false };
            return choices[random.Next(choices.Length)];
        }

        public double CalculateLoanPercent(int month, double amountPerMonth)
        {
            double minimum = month * amountPerMonth;

            // ფიქსირებული პროცენტი: მთლიანი თანხის 5%
            double interest = minimum * 0.05;

            // ჯამური გადასახდელი
            return minimum + interest;
        }
    }
}
