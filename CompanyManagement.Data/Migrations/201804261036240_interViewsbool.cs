namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interViewsbool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InterViews", "Result", c => c.Boolean());
            AlterColumn("dbo.InterViewsLists", "Result", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InterViewsLists", "Result", c => c.Boolean(nullable: false));
            AlterColumn("dbo.InterViews", "Result", c => c.Boolean(nullable: false));
        }
    }
}
