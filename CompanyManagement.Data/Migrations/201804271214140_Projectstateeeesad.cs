namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projectstateeeesad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminds", "ProjectId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminds", "ProjectId");
        }
    }
}
