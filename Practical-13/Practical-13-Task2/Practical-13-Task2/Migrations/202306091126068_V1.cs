namespace Practical_13_Task2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EmployeeByDesignations");
        }
        
        public override void Down()
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
    }
}
