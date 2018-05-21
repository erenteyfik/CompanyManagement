namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsadsadsadwqewq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "CustomerUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "CustomerUserName");
        }
    }
}
