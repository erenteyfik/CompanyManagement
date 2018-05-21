namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caaadsdsadsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "CashAccountId", c => c.Int(nullable: false));
            DropColumn("dbo.CashAccounts", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CashAccounts", "PaymentId", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "CashAccountId");
        }
    }
}
