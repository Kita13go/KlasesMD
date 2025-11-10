using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public interface IAdd
    {
        void addITSupport(ITSupport support);
        List<ITSupport> GetAllITSupports();
        void addTicket(Ticket ticket);
        List<Ticket> GetAllTickets();
        List<Employee> GetAllEmployees();
        List<Assignement> GetAllAssignments();
        void addAssignment(Assignement assignment);
    }
}
