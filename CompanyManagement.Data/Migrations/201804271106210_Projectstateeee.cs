namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projectstateeee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "StateName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "StateName");
        }
    }
}
