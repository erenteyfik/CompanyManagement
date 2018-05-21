namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cashaccountbankinfodasdas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentIncoming", "WhichSafe", c => c.String());
            AddColumn("dbo.PaymentOutGoing", "WhichSafe", c => c.String());
            DropColumn("dbo.PaymentIncoming", "WhoSafe");
            DropColumn("dbo.PaymentOutGoing", "WhoSafe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentOutGoing", "WhoSafe", c => c.String());
            AddColumn("dbo.PaymentIncoming", "WhoSafe", c => c.String());
            DropColumn("dbo.PaymentOutGoing", "WhichSafe");
            DropColumn("dbo.PaymentIncoming", "WhichSafe");
        }
    }
}
