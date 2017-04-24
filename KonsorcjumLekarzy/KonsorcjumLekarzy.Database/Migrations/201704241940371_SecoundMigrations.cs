namespace KonsorcjumLekarzy.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecoundMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDay = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropTable("dbo.Patients");
        }
    }
}
