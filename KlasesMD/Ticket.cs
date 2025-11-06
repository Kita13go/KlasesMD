using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasesMD
{
    public class Ticket
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int TicketID { get; set; }
        public Employee CreatedBy { get; set; }
        public enum TicketStatus
        {
            Open,
            InProgress,
            Resolved,
            Closed
        }  
        public TicketStatus Status { get; set; }
        public bool IsResolved { get; set; }
        // Pārdefinēta ToString metode, lai izvadītu visas īpašības
        public override string ToString()
        {
            return $"TicketID: {TicketID}, Title: {Title}, Description: {Description}, Priority: {Priority}, CreatedBy: [{CreatedBy}], Status: {Status}, IsResolved: {IsResolved}";
        }
    }
}
