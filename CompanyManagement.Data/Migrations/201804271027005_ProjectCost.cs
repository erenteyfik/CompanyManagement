namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectCost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectCostEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        EmployeeName = c.String(),
                        MonthlySalary = c.Int(),
                        MonthlyTax = c.Int(),
                        MonthlyInsurance = c.Int(),
                        MonthlyMeal = c.Int(),
                        MonthlyCarService = c.Int(),
                        MonthlyOtherExpenses = c.Int(),
                        Total = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectCostOthers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(nullable: false),
                        ProductName = c.String(),
                        Description = c.String(),
                        UnitQuantities = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            AddColumn("dbo.Projects", "ProjectState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectCostOthers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectCostEmployees", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectCostOthers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectCostEmployees", new[] { "ProjectId" });
            DropColumn("dbo.Projects", "ProjectState");
            DropTable("dbo.ProjectCostOthers");
            DropTable("dbo.ProjectCostEmployees");
        }
    }
}
