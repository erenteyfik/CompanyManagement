namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceProducts", "Total", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProducts", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
