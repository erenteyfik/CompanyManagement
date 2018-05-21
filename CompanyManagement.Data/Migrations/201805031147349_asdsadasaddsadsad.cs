namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsadasaddsadsad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminds", "CashAccountId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminds", "CashAccountId");
        }
    }
}
