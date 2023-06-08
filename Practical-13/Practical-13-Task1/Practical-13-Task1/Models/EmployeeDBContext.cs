using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_13_Task1.Models
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext() : base("name=EmployeeDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDBContext, Practical_13_Task1.Migrations.Configuration>());
        }
        public DbSet<Employee> Employees { get; set;}
    }
}