namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProducts", "UniqueId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProducts", "UniqueId");
        }
    }
}
