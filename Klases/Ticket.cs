using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int? EmployeeID { get; set; }
        public virtual Employee? Employee { get; set; }
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
            return $"Title: {Title}, Description: {Description}, Priority: {Priority}, CreatedBy: {Employee.UserName}, Status: {Status}, IsResolved: {IsResolved}";
        }
    }
}
