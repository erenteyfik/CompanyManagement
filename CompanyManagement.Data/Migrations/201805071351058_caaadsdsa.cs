namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caaadsdsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashAccounts", "PaymentId", c => c.Int(nullable: false));
            DropColumn("dbo.CashAccounts", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CashAccounts", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.CashAccounts", "PaymentId");
        }
    }
}
