namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cashaccountbankinfodas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashAccounts", "BankAccountNo", c => c.Int(nullable: false));
            DropColumn("dbo.CashAccounts", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CashAccounts", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.CashAccounts", "BankAccountNo");
        }
    }
}
