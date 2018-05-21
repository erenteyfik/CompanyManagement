namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceproductfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProducts", "IncomingId", c => c.Int());
            AddColumn("dbo.ServiceProducts", "OutGoingId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProducts", "OutGoingId");
            DropColumn("dbo.ServiceProducts", "IncomingId");
        }
    }
}
