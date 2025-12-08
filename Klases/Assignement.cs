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
        public int? ITSupportID { get; set; }
        public int? TicketID { get; set; }
        public string Comment { get; set; }
        public virtual ITSupport? ITSupport { get; set; }
        public virtual Ticket? Ticket { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $" Comment: {Comment}, AssignedAt: {AssignedAt}, Support: {ITSupport.UserName} - {ITSupport.Email}, Ticket: {Ticket.Title}, {Ticket.Description}";
        }
    }
}
