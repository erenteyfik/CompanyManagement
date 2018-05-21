namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Projectstateeeesadsa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reminds", name: "Company_Id", newName: "CompanyId");
            RenameIndex(table: "dbo.Reminds", name: "IX_Company_Id", newName: "IX_CompanyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reminds", name: "IX_CompanyId", newName: "IX_Company_Id");
            RenameColumn(table: "dbo.Reminds", name: "CompanyId", newName: "Company_Id");
        }
    }
}
