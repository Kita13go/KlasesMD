using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class Assignement
    {
        public int AssignementID { get; set; }
        public DateTime AssignedAt { get; set; }
        public int SupportID { get; set; }
        public int TicketID { get; set; }
        public string Comment { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $"Assignement ID: {AssignementID}, AssignedAt: {AssignedAt}, Support: {SupportID}, Ticket: {TicketID}, Comment: {Comment}";
        }
    }
}
