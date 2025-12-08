using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klases
{
    public class AddManager: IAdd, IRemove, IGetList
    {
        public Md3Context gc { get; set; }
        public AddManager(Md3Context _gc)
        {
            gc = _gc;
        }
        public void addEmployee(Employee emp)
        {
            try
            {
                gc.Employees.Add(emp);
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
        public bool removeEmployee(Employee emp)
        {
            try
            {
                gc.Employees.Remove(emp);
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public void addITSupport(ITSupport emp)
        {
            try
            {
                gc.ITSupports.Add(emp);
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
        public bool removeITSupport(ITSupport emp)
        {
            try
            {
                gc.ITSupports.Remove(emp);
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public void addTicket(Ticket emp)
        {
            try
            {
                gc.Tickets.Add(emp);
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
        public bool removeTicket(Ticket emp)
        {
            try
            {
                gc.Tickets.Remove(emp);
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public void addAssignement(Assignement emp)
        {
            try
            {
                gc.Assignements.Add(emp);
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
        public bool removeAssignement(Assignement emp)
        {
            try
            {
                gc.Assignements.Remove(emp);
                gc.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public void Save()
        {
            try
            {
                gc.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public List<Employee> getEmployeeList()
        {
            try
            {
                var list = gc.Employees.ToList();
                Debug.WriteLine(list.Count);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Employee>();
            }
        }

        public List<ITSupport> getITSupportList()
        {
            try
            {
                var list = gc.ITSupports.ToList();
                Debug.WriteLine(list.Count);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<ITSupport>();
            }
        }

        public List<Ticket> getTicketList()
        {
            try
            {
                var list = gc.Tickets.ToList();
                Debug.WriteLine(list.Count);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Ticket>();
            }
        }

        public List<Assignement> getAssignementList()
        {
            try
            {
                var list = gc.Assignements.ToList();
                Debug.WriteLine(list.Count);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Assignement>();
            }
        }
    }
}
