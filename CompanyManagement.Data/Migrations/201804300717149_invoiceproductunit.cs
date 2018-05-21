namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceproductunit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incoming", "Product_Unit", c => c.Int(nullable: false));
            AddColumn("dbo.OutGoing", "Product_Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OutGoing", "Product_Unit");
            DropColumn("dbo.Incoming", "Product_Unit");
        }
    }
}
