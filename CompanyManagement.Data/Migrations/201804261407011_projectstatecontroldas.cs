namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectstatecontroldas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "StateControl", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "StateControl", c => c.DateTime());
            AlterColumn("dbo.Projects", "End", c => c.DateTime());
            AlterColumn("dbo.Projects", "Start", c => c.DateTime());
        }
    }
}
