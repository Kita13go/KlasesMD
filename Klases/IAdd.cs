using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public interface IAdd
    {
        void addEmployee(Employee emp);
        void addITSupport(ITSupport emp);
        void addTicket(Ticket emp);
        void addAssignement(Assignement emp);
        void Save();
    }
}
