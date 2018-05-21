namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectstatecontrol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "StateControl", c => c.DateTime());
            AlterColumn("dbo.Projects", "Start", c => c.DateTime());
            AlterColumn("dbo.Projects", "End", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "StateControl");
        }
    }
}
