namespace Practical_13_Task2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabseAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Address = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
