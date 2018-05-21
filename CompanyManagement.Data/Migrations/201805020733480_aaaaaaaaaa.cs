namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaaaaaaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "Tax", c => c.Double(nullable: false));
        }
    }
}
