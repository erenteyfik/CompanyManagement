namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interView : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InterViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTime(),
                        WithWho = c.String(),
                        WhoUser = c.String(),
                        Result = c.Boolean(nullable: false),
                        InterViewType = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.InterViewsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreateTime = c.DateTime(),
                        WithWho = c.String(),
                        WhoUser = c.String(),
                        Result = c.Boolean(nullable: false),
                        InterViewType = c.String(),
                        CustomerId = c.Int(nullable: false),
                        InterViews_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.InterViews", t => t.InterViews_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.InterViews_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterViewsLists", "InterViews_Id", "dbo.InterViews");
            DropForeignKey("dbo.InterViewsLists", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.InterViews", "CustomerId", "dbo.Customers");
            DropIndex("dbo.InterViewsLists", new[] { "InterViews_Id" });
            DropIndex("dbo.InterViewsLists", new[] { "CustomerId" });
            DropIndex("dbo.InterViews", new[] { "CustomerId" });
            DropTable("dbo.InterViewsLists");
            DropTable("dbo.InterViews");
        }
    }
}
