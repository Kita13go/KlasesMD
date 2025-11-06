using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasesMD
{
    public class Employee: User
    {
        public DateTime ContractDate { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības (arī mantoto)
        public override string ToString()
        {
            return base.ToString() + $", ContractDate: {ContractDate.ToShortDateString()}";
        }
    }
}
