using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasesMD
{
    public class Assignement
    {
        public int AssignementID { get; set; }
        public DateTime AssignedAt { get; set; }
        public ITSupport Support { get; set; }
        public Ticket Ticket { get; set; }
        public string Comment { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $"Assignement ID: {AssignementID}, AssignedAt: {AssignedAt}, Support: [{Support}], Ticket: [{Ticket}], Comment: {Comment}";
        }
    }
}
