namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incoming", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OutGoing", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.OutGoing", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.Incoming", "Total", c => c.Double(nullable: false));
        }
    }
}
