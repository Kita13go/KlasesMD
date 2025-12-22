using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Klases.ITSupport;
using static Klases.Ticket;


namespace Klases
{
    public class Md3Context: DbContext
    {
        public Md3Context(DbContextOptions<Md3Context> options): base(options)
        {
        }

        public Md3Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string cs = ConfigurationManager.ConnectionStrings ["Md3DB"].ConnectionString;
            //string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MD3;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //optionsBuilder.UseSqlServer(cs);
        }
        /// DB izveidoju ar magrācijas palīdzību

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ITSupport> ITSupports { get; set; }
        public DbSet<Assignement> Assignements { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // Pievienoju, lai dzēšot ITSupport vai Ticket, Assignement tabulā attiecīgais lauks tiktu iestatīts uz null
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignement>()
                .HasOne(a => a.ITSupport)
                .WithMany()
                .HasForeignKey(a => a.ITSupportID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Assignement>()
                .HasOne(a => a.Ticket)
                .WithMany()
                .HasForeignKey(a => a.TicketID)
                .OnDelete(DeleteBehavior.SetNull);

            // Testa dati
            // IT atbalsta darbinieki, šai klasei ir konstruktors, kurš automatiski aizpilda laukus
            modelBuilder.Entity<ITSupport>().HasData(
                new ITSupport {
                    UserID = 1,
                    UserName = "Marta Liepa",
                    Email = "marta.liepa@gmail.com",
                    IsActive = true,
                    Specialization = SpecializationType.Network
                },
                new ITSupport {
                    UserID = 2,
                    UserName = "Edgars Kalniņš",
                    Email = "edgars.kalnins@gmail.com",
                    IsActive = true,
                    Specialization = SpecializationType.Software
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    UserID = 1,
                    UserName = "Anna Ozola",
                    Email = "anna.ozola@gmail.com",
                    IsActive = true,
                    ContractDate = new DateTime(2020, 5, 10)
                },
                new Employee
                {
                    UserID = 2,
                    UserName = "Jānis Bērziņš",
                    Email = "janis.berzins@gmail.com",
                    IsActive = true,
                    ContractDate = new DateTime(2021, 3, 20)
                }
            );

            //Biļetes 
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    TicketID = 1,
                    Title = "printeris nestrādā",
                    Description = "Printeris 2. stāvā neieslēdzas.",
                    Priority = 2,
                    EmployeeID = 1,
                    Status = TicketStatus.Open,
                    IsResolved = false
                },
                new Ticket
                {
                    TicketID = 2,   
                    Title = "Programmas kļūda",
                    Description = "Excel nereaģē uz peles klikšķiem.",
                    Priority = 3,
                    EmployeeID = 2,
                    Status = TicketStatus.InProgress,
                    IsResolved = false
                }
            );

            // Piešķīrumi
            modelBuilder.Entity<Assignement>().HasData(
                new Assignement
                {
                    AssignementID = 1,
                    AssignedAt = new DateTime(2025, 6, 7),
                    TicketID = 1,
                    ITSupportID = 1,
                    Comment = "Pārbaudīt printera barošanu."
                },
                new Assignement
                {
                    AssignementID = 2,
                    AssignedAt = new DateTime(2025, 3, 12),
                    ITSupportID = 2,
                    TicketID = 2,
                    Comment = "Notestēt Excel atjauninājumu."
                }
            );

        }

    }
}
