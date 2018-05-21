namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cashaccountedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashAccounts", "AccountRate", c => c.String());
            AlterColumn("dbo.CashAccounts", "AccountType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CashAccounts", "AccountType", c => c.String());
            DropColumn("dbo.CashAccounts", "AccountRate");
        }
    }
}
