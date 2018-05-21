namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsadasad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        AccountName = c.String(),
                        AccountType = c.String(),
                        OpeningAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CashAccounts");
        }
    }
}
