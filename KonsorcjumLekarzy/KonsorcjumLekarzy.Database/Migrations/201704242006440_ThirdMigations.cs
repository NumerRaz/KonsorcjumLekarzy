namespace KonsorcjumLekarzy.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Confirmation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Visits", new[] { "PatientId" });
            DropIndex("dbo.Visits", new[] { "DoctorId" });
            DropTable("dbo.Visits");
        }
    }
}
