namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interViewsboolbool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InterViews", "Result", c => c.Boolean(nullable: false));
            AlterColumn("dbo.InterViewsLists", "Result", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InterViewsLists", "Result", c => c.Boolean());
            AlterColumn("dbo.InterViews", "Result", c => c.Boolean());
        }
    }
}
