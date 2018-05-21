namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interViewList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InterViewsLists", "CustomerId", "dbo.Customers");
            DropIndex("dbo.InterViewsLists", new[] { "CustomerId" });
            DropColumn("dbo.InterViewsLists", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InterViewsLists", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.InterViewsLists", "CustomerId");
            AddForeignKey("dbo.InterViewsLists", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
