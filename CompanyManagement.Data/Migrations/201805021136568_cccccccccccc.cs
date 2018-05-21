namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cccccccccccc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incoming", "AraToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Incoming", "KDVToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Incoming", "GenelToplam", c => c.Double(nullable: false));
            AddColumn("dbo.OutGoing", "AraToplam", c => c.Double(nullable: false));
            AddColumn("dbo.OutGoing", "KDVToplam", c => c.Double(nullable: false));
            AddColumn("dbo.OutGoing", "GenelToplam", c => c.Double(nullable: false));
            DropColumn("dbo.Invoices", "AraToplam");
            DropColumn("dbo.Invoices", "KDVToplam");
            DropColumn("dbo.Invoices", "GenelToplam");
            DropColumn("dbo.Incoming", "Total");
            DropColumn("dbo.Incoming", "Product_Unit");
            DropColumn("dbo.OutGoing", "Total");
            DropColumn("dbo.OutGoing", "Product_Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OutGoing", "Product_Unit", c => c.Int(nullable: false));
            AddColumn("dbo.OutGoing", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.Incoming", "Product_Unit", c => c.Int(nullable: false));
            AddColumn("dbo.Incoming", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "GenelToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "KDVToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "AraToplam", c => c.Double(nullable: false));
            DropColumn("dbo.OutGoing", "GenelToplam");
            DropColumn("dbo.OutGoing", "KDVToplam");
            DropColumn("dbo.OutGoing", "AraToplam");
            DropColumn("dbo.Incoming", "GenelToplam");
            DropColumn("dbo.Incoming", "KDVToplam");
            DropColumn("dbo.Incoming", "AraToplam");
        }
    }
}
