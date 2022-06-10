using WorkingConsoleDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingConsoleDB.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Email> EmailAddress { get; set; }
        //protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(MainWindow.ConnectionString);
        //}
    }
}
