namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doublevalue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incoming", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.OutGoing", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Double(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProducts", "UnitPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceProducts", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.OutGoing", "Total", c => c.Int(nullable: false));
            AlterColumn("dbo.Incoming", "Total", c => c.Int(nullable: false));
        }
    }
}
