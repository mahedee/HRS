namespace HRS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyFacilities", "FacilitiesName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyFacilities", "FacilitiesName", c => c.String());
        }
    }
}
