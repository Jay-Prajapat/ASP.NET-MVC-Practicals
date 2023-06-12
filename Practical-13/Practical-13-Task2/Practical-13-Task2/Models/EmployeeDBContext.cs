using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Practical_13_Task2.Models
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext() : base("name=EmplpoyeeDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDBContext, Practical_13_Task2.Migrations.Configuration>());
        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Designation> Designations { get; set;}

       
    }
}