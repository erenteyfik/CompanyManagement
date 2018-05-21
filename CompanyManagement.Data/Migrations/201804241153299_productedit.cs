namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProducts", "UnitPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProducts", "UnitPrice");
        }
    }
}
