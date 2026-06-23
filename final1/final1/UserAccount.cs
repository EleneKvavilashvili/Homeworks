using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final1
{
    internal class UserAccount
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public CardDetails CardDetails {  get; set; }
        public List<Transaction> TransactionHistory {  get; set; } = new List<Transaction>();
    }
}
