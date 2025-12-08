using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace Klases
{
    public class Md3Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = ConfigurationManager.ConnectionStrings ["Md3DB"].ConnectionString;
            optionsBuilder.UseSqlServer(cs);
        }
        /// DB izveidoju ar magrācijas palīdzību

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ITSupport> ITSupports { get; set; }
        public DbSet<Assignement> Assignements { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
