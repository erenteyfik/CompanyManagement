namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbbbbbbbbb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "AraToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "KDVToplam", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "GenelToplam", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "GenelToplam");
            DropColumn("dbo.Invoices", "KDVToplam");
            DropColumn("dbo.Invoices", "AraToplam");
        }
    }
}
