using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8
{
    internal class MicroFinance : IFinanceOperations
    {
        public bool CheckUserHistory()
        {
            return true;
        }

        public double CalculateLoanPercent(int month, double amountPerMonth)
        {
            double minimum = month * amountPerMonth;
            double commission = minimum * 0.10;
            double monthlyServiceFee = month * 4;

            return minimum + commission + monthlyServiceFee;
        }
    }
}
