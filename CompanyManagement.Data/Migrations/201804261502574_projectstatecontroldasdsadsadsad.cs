namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectstatecontroldasdsadsadsad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TimeControl", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "StateControl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "StateControl", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "TimeControl");
        }
    }
}
