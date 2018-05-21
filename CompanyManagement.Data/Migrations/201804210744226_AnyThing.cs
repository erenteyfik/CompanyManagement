namespace CompanyManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnyThing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CompanyId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        AuthorizedPerson = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Budget = c.String(),
                        CustomerActive = c.Boolean(nullable: false),
                        BankName = c.String(),
                        IBANno = c.String(),
                        CompanyTitle = c.String(),
                        TaxOffice = c.String(),
                        TaxorTCNo = c.String(),
                        CompanyPhone = c.String(),
                        FaxNo = c.String(),
                        Address = c.String(),
                        Province = c.String(),
                        District = c.String(),
                        WebAddress = c.String(),
                        CustomerTime = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CustomerUserName = c.String(),
                        Description = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.ServiceProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Tax = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Incoming_Id = c.Int(),
                        OutGoing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Incoming", t => t.Incoming_Id)
                .ForeignKey("dbo.OutGoing", t => t.OutGoing_Id)
                .Index(t => t.Incoming_Id)
                .Index(t => t.OutGoing_Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Who = c.String(),
                        Description = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        WhichTransaction = c.String(),
                        Customer_Id = c.Int(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Reminds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        WhoUser = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Description = c.String(),
                        CustomerUserName = c.String(),
                        Sorumluenumolacak = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        Description = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Incoming",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        ProcessTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.OutGoing",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        ProcessTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PaymentIncoming",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        WhoSafe = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PaymentOutGoing",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Total = c.Int(nullable: false),
                        WhoSafe = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payments", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentOutGoing", "Id", "dbo.Payments");
            DropForeignKey("dbo.PaymentIncoming", "Id", "dbo.Payments");
            DropForeignKey("dbo.OutGoing", "Id", "dbo.Invoices");
            DropForeignKey("dbo.Incoming", "Id", "dbo.Invoices");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Expenses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Reminds", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Projects", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Projects", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Logs", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Reminds", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Logs", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ServiceProducts", "OutGoing_Id", "dbo.OutGoing");
            DropForeignKey("dbo.ServiceProducts", "Incoming_Id", "dbo.Incoming");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PaymentOutGoing", new[] { "Id" });
            DropIndex("dbo.PaymentIncoming", new[] { "Id" });
            DropIndex("dbo.OutGoing", new[] { "Id" });
            DropIndex("dbo.Incoming", new[] { "Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Expenses", new[] { "CustomerId" });
            DropIndex("dbo.Projects", new[] { "Company_Id" });
            DropIndex("dbo.Projects", new[] { "CustomerId" });
            DropIndex("dbo.Reminds", new[] { "Company_Id" });
            DropIndex("dbo.Reminds", new[] { "CustomerId" });
            DropIndex("dbo.Payments", new[] { "CustomerId" });
            DropIndex("dbo.Logs", new[] { "Company_Id" });
            DropIndex("dbo.Logs", new[] { "Customer_Id" });
            DropIndex("dbo.ServiceProducts", new[] { "OutGoing_Id" });
            DropIndex("dbo.ServiceProducts", new[] { "Incoming_Id" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropTable("dbo.PaymentOutGoing");
            DropTable("dbo.PaymentIncoming");
            DropTable("dbo.OutGoing");
            DropTable("dbo.Incoming");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Expenses");
            DropTable("dbo.Projects");
            DropTable("dbo.Reminds");
            DropTable("dbo.Payments");
            DropTable("dbo.Logs");
            DropTable("dbo.ServiceProducts");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
        }
    }
}
