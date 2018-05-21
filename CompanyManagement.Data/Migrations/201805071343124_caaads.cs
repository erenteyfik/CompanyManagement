namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caaads : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashAccounts", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashAccounts", "CustomerId");
        }
    }
}
