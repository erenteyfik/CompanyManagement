namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timecustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "CustomerTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "CreateTime");
        }
    }
}
