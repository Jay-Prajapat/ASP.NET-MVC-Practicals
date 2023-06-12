namespace Practical_13_Task2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmplpoyeeDesignationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeByDesignations",
                c => new
                    {
                        Designation = c.String(nullable: false, maxLength: 128),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Designation);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeByDesignations");
        }
    }
}
