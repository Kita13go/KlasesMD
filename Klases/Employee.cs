using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class Employee
    {
        /// Pievienoju visus nepieciešamos laukus un īpašības no User klases
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime ContractDate { get; set; }

        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $"Username: {UserName}, Email: {Email}, IsActive: {IsActive}, ContractDate: {ContractDate.ToShortDateString()}";
        }

    }
}
