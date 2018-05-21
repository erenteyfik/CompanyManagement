namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incoming", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Incoming", "ProcessTime", c => c.DateTime());
            AlterColumn("dbo.OutGoing", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.OutGoing", "ProcessTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OutGoing", "ProcessTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OutGoing", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incoming", "ProcessTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incoming", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
