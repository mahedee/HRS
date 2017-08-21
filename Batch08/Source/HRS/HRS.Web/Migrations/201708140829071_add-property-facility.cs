namespace HRS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpropertyfacility : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyFacilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacilitiesName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyFacilityProperties",
                c => new
                    {
                        PropertyFacility_Id = c.Int(nullable: false),
                        Property_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PropertyFacility_Id, t.Property_Id })
                .ForeignKey("dbo.PropertyFacilities", t => t.PropertyFacility_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Property_Id, cascadeDelete: true)
                .Index(t => t.PropertyFacility_Id)
                .Index(t => t.Property_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyFacilityProperties", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.PropertyFacilityProperties", "PropertyFacility_Id", "dbo.PropertyFacilities");
            DropIndex("dbo.PropertyFacilityProperties", new[] { "Property_Id" });
            DropIndex("dbo.PropertyFacilityProperties", new[] { "PropertyFacility_Id" });
            DropTable("dbo.PropertyFacilityProperties");
            DropTable("dbo.PropertyFacilities");
        }
    }
}
