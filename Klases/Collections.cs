using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class Collections: IAdd
    {
        // Kolekcijas ar visiem iepriekš definētajiem klašu objektiem
        // Klase User nav iekļauta, jo tā ir abstrakta un nevar tikt instancēta
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<ITSupport> ITSupports { get; set; } = new List<ITSupport>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<Assignement> Assignements { get; set; } = new List<Assignement>();
        public override string ToString() // Pārdefinēta ToString metode, lai izvadītu visu kolekciju saturu 
        { // (teik ģenerēta automatiski)
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Employees:");
            foreach (var emp in Employees)
            {
                sb.AppendLine(emp.ToString());
            }
            sb.AppendLine("\nIT Supports:");
            foreach (var support in ITSupports)
            {
                sb.AppendLine(support.ToString());
            }
            sb.AppendLine("\nTickets:");
            foreach (var ticket in Tickets)
            {
                sb.AppendLine(ticket.ToString());
            }
            sb.AppendLine("\nAssignements:");
            foreach (var assign in Assignements)
            {
                sb.AppendLine(assign.ToString());
            }
            return sb.ToString();
        }
        public void addITSupport(ITSupport support)
        {
            ITSupports.Add(support);
        }
        public List<ITSupport> GetAllITSupports()
        {
            return ITSupports;
        }
        public void addTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public List<Ticket> GetAllTickets()
        {
            return Tickets;
        }
        public List<Assignement> GetAllAssignments()
        {
            return Assignements;
        }
        public void addAssignment(Assignement assignment)
        {
            Assignements.Add(assignment);
        }
    }
}
