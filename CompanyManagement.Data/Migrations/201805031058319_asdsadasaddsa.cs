namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsadasaddsa : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CashAccounts", "CompanyId");
            AddForeignKey("dbo.CashAccounts", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashAccounts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CashAccounts", new[] { "CompanyId" });
        }
    }
}
