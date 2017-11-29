namespace HRS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11292017 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facilities", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facilities", "Name", c => c.String());
        }
    }
}
