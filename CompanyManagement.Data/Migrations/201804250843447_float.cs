namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _float : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incoming", "Total", c => c.Single(nullable: false));
            AlterColumn("dbo.OutGoing", "Total", c => c.Single(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Single(nullable: false));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Single(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OutGoing", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Incoming", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
