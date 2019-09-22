namespace ALFATEX4TRADE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpeningAndEndings",
                c => new
                    {
                        OpeningBalace = c.Double(nullable: false),
                        EndingBalace = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OpeningBalace);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BillNumber = c.Int(),
                        Date = c.DateTime(),
                        JournalDate = c.DateTime(),
                        ClientID = c.String(),
                        ProductID = c.String(),
                        ProductName = c.String(),
                        Price = c.Double(),
                        CleintName = c.String(),
                        Bag = c.Double(),
                        DailyID = c.Int(),
                        Total = c.Double(),
                        Size = c.String(),
                        Outgoing = c.Double(),
                        counter = c.Int(nullable: false),
                        GeneralTotal = c.Double(nullable: false),
                        GBags = c.Double(nullable: false),
                        Goutgoing = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cleints",
                c => new
                    {
                        AccountID = c.String(nullable: false, maxLength: 128),
                        AccountName = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DailyNum = c.Int(nullable: false),
                        AccountID = c.String(),
                        Date = c.DateTime(),
                        DR = c.Double(),
                        CR = c.Double(),
                        AccountName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EditRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimNumber = c.Int(nullable: false),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.String(nullable: false, maxLength: 128),
                        EmpName = c.String(),
                        Brithday = c.DateTime(),
                        insurance = c.Boolean(nullable: false),
                        Department = c.String(),
                        Section = c.String(),
                        Base = c.Double(nullable: false),
                        Status = c.String(),
                        AbsenceDays = c.Int(),
                        OverTime = c.Double(),
                        Late = c.Double(),
                        PermissionTime = c.Double(),
                        PermissiomTimeValue = c.Double(),
                        Loan = c.Double(),
                        BuyValue = c.Double(),
                        Transportation = c.Double(),
                        Address = c.String(),
                        penalty = c.Double(),
                        OvertimeValue = c.Double(),
                        PureSalary = c.Double(nullable: false),
                        DisInsurance = c.String(),
                        InsuranceValue = c.Double(),
                        LateValue = c.Double(),
                        Cuthafiz = c.Double(),
                        Totcut = c.Double(),
                        TotAdd = c.Double(),
                        AbsenceValue = c.Double(),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.Primissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PrimNumber = c.Int(nullable: false),
                        Date = c.DateTime(),
                        ClientID = c.String(),
                        ProductID = c.String(),
                        ProductName = c.String(),
                        Outgoing = c.Double(nullable: false),
                        CleintName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Size = c.String(),
                        Incoming = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        Session = c.String(),
                        ValueToID = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Products");
            DropTable("dbo.Primissions");
            DropTable("dbo.Employees");
            DropTable("dbo.EditRequests");
            DropTable("dbo.Data");
            DropTable("dbo.Cleints");
            DropTable("dbo.Bills");
            DropTable("dbo.OpeningAndEndings");
        }
    }
}
