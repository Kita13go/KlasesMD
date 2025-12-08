using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public interface IRemove
    {
        bool removeEmployee(Employee emp);
        bool removeITSupport(ITSupport emp);
        bool removeTicket(Ticket emp);
        bool removeAssignement(Assignement emp);
    }
}
