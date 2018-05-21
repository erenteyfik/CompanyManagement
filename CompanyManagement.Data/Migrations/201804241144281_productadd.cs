namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incoming", "SProduct_Id", c => c.Int());
            AddColumn("dbo.OutGoing", "SProduct_Id", c => c.Int());
            CreateIndex("dbo.Incoming", "SProduct_Id");
            CreateIndex("dbo.OutGoing", "SProduct_Id");
            AddForeignKey("dbo.Incoming", "SProduct_Id", "dbo.ServiceProducts", "Id");
            AddForeignKey("dbo.OutGoing", "SProduct_Id", "dbo.ServiceProducts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OutGoing", "SProduct_Id", "dbo.ServiceProducts");
            DropForeignKey("dbo.Incoming", "SProduct_Id", "dbo.ServiceProducts");
            DropIndex("dbo.OutGoing", new[] { "SProduct_Id" });
            DropIndex("dbo.Incoming", new[] { "SProduct_Id" });
            DropColumn("dbo.OutGoing", "SProduct_Id");
            DropColumn("dbo.Incoming", "SProduct_Id");
        }
    }
}
