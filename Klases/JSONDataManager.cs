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
    public class JSONDataManager: IDataManager, IAdd
    {
        public Collections collections { get; set; }
        public string filePath { get; set; } = "C:\\Temp\\data.txt"; // Noklusētais ceļš uz datni

        // Konstruktoru pārslogošana, lai varētu izveidot ar vai bez ceļa parametra
        public JSONDataManager()
        {
            this.collections = new Collections();
        }
        public JSONDataManager(string path) : this()
        {
            if (path != "")
                this.filePath = path;
        }

        public void addAssignment(Assignement assignment)
        {
            throw new NotImplementedException();
        }

        public void addITSupport(ITSupport support)
        {
            throw new NotImplementedException();
        }

        public void addTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void createTestData()
        {
            // Testa piemērus pajautāju ChatGPT, jo pašam nav tik daudz fantāzijas, lai to visu izdomātu :) saite: https://chatgpt.com/
            // Divi darbnieka piemēri
            var e1 = new Employee
            {
                UserID = 1,
                UserName = "Anna Ozola",
                Email = "anna.ozola@gmail.com",
                IsActive = true,
                ContractDate = new DateTime(2020, 5, 10)
            };
            var e2 = new Employee
            {
                UserID = 2,
                UserName = "Jānis Bērziņš",
                Email = "janis.berzins@gmail.com",
                IsActive = true,
                ContractDate = new DateTime(2021, 3, 20)
            };
            collections.Employees.AddRange(new[] { e1, e2 });

            // IT atbalsta darbinieki, šai klasei ir konstruktors, kurš automatiski aizpilda laukus
            var s1 = new ITSupport("Marta Liepa", "marta.liepa@gmail.com", 3, true, SpecializationType.Network);
            var s2 = new ITSupport("Edgars Kalniņš", "edgars.kalnins@gmail.com", 4, true, SpecializationType.Software);
            collections.ITSupports.AddRange(new[] { s1, s2 });

            //Biļetes 
            var t1 = new Ticket
            {
                TicketID = 101,
                Title = "printeris nestrādā",
                Description = "Printeris 2. stāvā neieslēdzas.",
                Priority = 2,
                CreatedBy = e1,
                Status = TicketStatus.Open,
                IsResolved = false
            };
            var t2 = new Ticket
            {
                TicketID = 102,
                Title = "Programmas kļūda",
                Description = "Excel nereaģē uz peles klikšķiem.",
                Priority = 3,
                CreatedBy = e2,
                Status = TicketStatus.InProgress,
                IsResolved = false
            };
            collections.Tickets.AddRange(new[] { t1, t2 });

            // Piešķīrumi
            var a1 = new Assignement
            {
                AssignementID = 1,
                AssignedAt = DateTime.Now,
                Ticket = t1,
                Support = s1,
                Comment = "Pārbaudīt printera barošanu."
            };

            var a2 = new Assignement
            {
                AssignementID = 2,
                AssignedAt = DateTime.Now,
                Support = s2,
                Ticket = t2,
                Comment = "Notestēt Excel atjauninājumu."
            };
            collections.Assignements.AddRange(new[] { a1, a2 });

        }

        public List<Assignement> GetAllAssignments()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public List<ITSupport> GetAllITSupports()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAllTickets()
        {
            throw new NotImplementedException();
        }

        public void load() // No Jūsu piemēra, bet bez bool atgriešanas
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    Collections c = JsonSerializer.Deserialize<Collections>(jsonString);

                    if (c != null) { collections = c; }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public string print()
        {
            string result = collections.ToString();
            return result;
        }

        public void reset()
        {
            collections = new Collections();
        }

        public void save() // No jūsu piemēra, bet bez bool atgriešanas
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(collections);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        
    }
}
