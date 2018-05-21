namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "WhoUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "WhoUser");
        }
    }
}
