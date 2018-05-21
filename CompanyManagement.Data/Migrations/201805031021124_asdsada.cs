namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdsada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reminds", "UploadTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reminds", "UploadTime");
        }
    }
}
