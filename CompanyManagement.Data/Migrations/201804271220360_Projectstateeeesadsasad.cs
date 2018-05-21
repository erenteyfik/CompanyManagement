namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projectstateeeesadsasad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reminds", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reminds", new[] { "CustomerId" });
            AlterColumn("dbo.Reminds", "CustomerId", c => c.Int());
            CreateIndex("dbo.Reminds", "CustomerId");
            AddForeignKey("dbo.Reminds", "CustomerId", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reminds", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reminds", new[] { "CustomerId" });
            AlterColumn("dbo.Reminds", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reminds", "CustomerId");
            AddForeignKey("dbo.Reminds", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
