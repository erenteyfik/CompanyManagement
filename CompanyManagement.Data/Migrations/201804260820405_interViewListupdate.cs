namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class interViewListupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InterViewsLists", "InterViews_Id", "dbo.InterViews");
            DropIndex("dbo.InterViewsLists", new[] { "InterViews_Id" });
            RenameColumn(table: "dbo.InterViewsLists", name: "InterViews_Id", newName: "InterViewsId");
            AlterColumn("dbo.InterViewsLists", "InterViewsId", c => c.Int(nullable: false));
            CreateIndex("dbo.InterViewsLists", "InterViewsId");
            AddForeignKey("dbo.InterViewsLists", "InterViewsId", "dbo.InterViews", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InterViewsLists", "InterViewsId", "dbo.InterViews");
            DropIndex("dbo.InterViewsLists", new[] { "InterViewsId" });
            AlterColumn("dbo.InterViewsLists", "InterViewsId", c => c.Int());
            RenameColumn(table: "dbo.InterViewsLists", name: "InterViewsId", newName: "InterViews_Id");
            CreateIndex("dbo.InterViewsLists", "InterViews_Id");
            AddForeignKey("dbo.InterViewsLists", "InterViews_Id", "dbo.InterViews", "Id");
        }
    }
}
