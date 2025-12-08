using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Klases.ITSupport;
using static Klases.Ticket;

namespace Klases
{
    public class DBDataManager: IDataManager
    {
        public Md3Context gc { get; set; }
        public AddManager am { get; set; }

        // Konstruktoru pārslogošana, lai varētu izveidot ar vai bez ceļa parametra
        public DBDataManager()
        {
            gc = new Md3Context();
            am = new AddManager(gc);
        }

        public void createTestData()
        {
            try
            {
                // Testa piemērus pajautāju ChatGPT, jo pašam nav tik daudz fantāzijas, lai to visu izdomātu :) saite: https://chatgpt.com/
                // Divi darbnieka piemēri
                var e1 = new Employee
                {
                    UserName = "Anna Ozola",
                    Email = "anna.ozola@gmail.com",
                    IsActive = true,
                    ContractDate = new DateTime(2020, 5, 10)
                };
                var e2 = new Employee
                {
                    UserName = "Jānis Bērziņš",
                    Email = "janis.berzins@gmail.com",
                    IsActive = true,
                    ContractDate = new DateTime(2021, 3, 20)
                };
                gc.Employees.Add(e1);
                gc.Employees.Add(e2);
                save();

                // IT atbalsta darbinieki, šai klasei ir konstruktors, kurš automatiski aizpilda laukus
                var s1 = new ITSupport("Marta Liepa", "marta.liepa@gmail.com", true, SpecializationType.Network);
                var s2 = new ITSupport("Edgars Kalniņš", "edgars.kalnins@gmail.com", true, SpecializationType.Software);
                gc.ITSupports.AddRange(new[] { s1, s2 });
                save();
                //Biļetes 
                var t1 = new Ticket
                {
                    Title = "printeris nestrādā",
                    Description = "Printeris 2. stāvā neieslēdzas.",
                    Priority = 2,
                    EmployeeID = e1.UserID,
                    Status = TicketStatus.Open,
                    IsResolved = false
                };
                var t2 = new Ticket
                {
                    Title = "Programmas kļūda",
                    Description = "Excel nereaģē uz peles klikšķiem.",
                    Priority = 3,
                    EmployeeID = e2.UserID,
                    Status = TicketStatus.InProgress,
                    IsResolved = false
                };
                gc.Tickets.AddRange(new[] { t1, t2 });
                save();
                // Piešķīrumi
                var a1 = new Assignement
                {
                    AssignedAt = DateTime.Now,
                    TicketID = t1.TicketID,
                    ITSupportID = s1.UserID,
                    Comment = "Pārbaudīt printera barošanu."
                };

                var a2 = new Assignement
                {
                    AssignedAt = DateTime.Now,
                    ITSupportID = s2.UserID,
                    TicketID = t2.TicketID,
                    Comment = "Notestēt Excel atjauninājumu."
                };
                gc.Assignements.Add(a1);
                gc.Assignements.Add(a2);
                save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        public void load() // No Jūsu piemēra, bet bez bool atgriešanas
        {
            try
            {
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        public string print()
        {
            try
            {
                string s = "Employees: " + Environment.NewLine;
                foreach (var figure in gc.Employees)
                {
                    s += figure.ToString() + Environment.NewLine;
                }
                s += "ITSupports: " + Environment.NewLine;
                foreach (var figure in gc.ITSupports)
                {
                    s += figure.ToString() + Environment.NewLine;
                }
                s += "Tickets: " + Environment.NewLine;
                foreach (var figure in gc.Tickets)
                {
                    s += figure.ToString() + Environment.NewLine;
                }
                s += "Assignements: " + Environment.NewLine;
                foreach (var figure in gc.Assignements)
                {
                    s += figure.ToString() + Environment.NewLine;
                }
                return s;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "";
            }
        }

        public void reset()
        {
            try
            {
                // Izdzēšam tabulas Assignements datus (sākam no tiem, jo tie atsaucas uz pārējām tabulām)
                gc.Assignements.RemoveRange(gc.Assignements);
                save();

                // izdzēšam tabulas Tickets datus
                gc.Tickets.RemoveRange(gc.Tickets);
                save();

                // izdzēšam tabulas ITSupports datus
                gc.ITSupports.RemoveRange(gc.ITSupports);
                save();

                // Izdzēšam tabulas Employees datus
                gc.Employees.RemoveRange(gc.Employees);
                save();

                // Inicializējam AddManager no jauna    
                am = new AddManager(gc);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }

        public void save() // No jūsu piemēra, bet bez bool atgriešanas
        {
            try
            {
                gc.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
        }
    }
}
