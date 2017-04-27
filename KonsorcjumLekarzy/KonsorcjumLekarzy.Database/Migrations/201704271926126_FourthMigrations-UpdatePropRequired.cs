namespace KonsorcjumLekarzy.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigrationsUpdatePropRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "BirthDay", c => c.String());
            AlterColumn("dbo.Patients", "BirthDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "BirthDay", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "BirthDay", c => c.String(nullable: false));
        }
    }
}
