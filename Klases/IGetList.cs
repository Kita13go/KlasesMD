using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public interface IGetList
    {
        List<Employee> getEmployeeList();
        List<ITSupport> getITSupportList();
        List<Ticket> getTicketList();
        List<Assignement> getAssignementList();
    }
}
