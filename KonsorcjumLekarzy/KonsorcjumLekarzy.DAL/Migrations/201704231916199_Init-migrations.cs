namespace KonsorcjumLekarzy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUser", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUser", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.String(),
                        SpecializationId = c.Int(nullable: false),
                        UserId = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DoctorId)
                .ForeignKey("dbo.AspNetUser", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        SpecializationName = c.String(),
                        SpecializationDescription = c.String(),
                        Doctor_DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.SpecializationId)
                .ForeignKey("dbo.Doctor", t => t.Doctor_DoctorId)
                .Index(t => t.Doctor_DoctorId);
            
            CreateTable(
                "dbo.AspNetUserAspNetRole",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUser", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRole", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialization", "Doctor_DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Doctor", "AspNetUser_Id", "dbo.AspNetUser");
            DropForeignKey("dbo.AspNetUserLogin", "AspNetUser_Id", "dbo.AspNetUser");
            DropForeignKey("dbo.AspNetUserClaim", "AspNetUser_Id", "dbo.AspNetUser");
            DropForeignKey("dbo.AspNetUserAspNetRole", "AspNetRole_Id", "dbo.AspNetRole");
            DropForeignKey("dbo.AspNetUserAspNetRole", "AspNetUser_Id", "dbo.AspNetUser");
            DropIndex("dbo.AspNetUserAspNetRole", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRole", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Specialization", new[] { "Doctor_DoctorId" });
            DropIndex("dbo.Doctor", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogin", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaim", new[] { "AspNetUser_Id" });
            DropTable("dbo.AspNetUserAspNetRole");
            DropTable("dbo.Specialization");
            DropTable("dbo.Doctor");
            DropTable("dbo.AspNetUserLogin");
            DropTable("dbo.AspNetUserClaim");
            DropTable("dbo.AspNetUser");
            DropTable("dbo.AspNetRole");
        }
    }
}
