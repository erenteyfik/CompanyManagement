namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cashaccountbankinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashAccounts", "BankName", c => c.String());
            AddColumn("dbo.CashAccounts", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.CashAccounts", "IBAN", c => c.String());
            AddColumn("dbo.CashAccounts", "BranchCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashAccounts", "BranchCode");
            DropColumn("dbo.CashAccounts", "IBAN");
            DropColumn("dbo.CashAccounts", "MyProperty");
            DropColumn("dbo.CashAccounts", "BankName");
        }
    }
}
