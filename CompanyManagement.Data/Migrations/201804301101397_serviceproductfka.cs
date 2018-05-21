namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceproductfka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProducts", "InvoiceId", c => c.Int());
            DropColumn("dbo.ServiceProducts", "IncomingId");
            DropColumn("dbo.ServiceProducts", "OutGoingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceProducts", "OutGoingId", c => c.Int());
            AddColumn("dbo.ServiceProducts", "IncomingId", c => c.Int());
            DropColumn("dbo.ServiceProducts", "InvoiceId");
        }
    }
}
