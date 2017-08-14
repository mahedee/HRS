namespace HRS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcountry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Properties", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Properties", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Properties", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.Properties", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Properties", new[] { "CountryId" });
            DropIndex("dbo.Properties", new[] { "CityId" });
            DropIndex("dbo.Properties", new[] { "PropertyTypeId" });
            DropIndex("dbo.Properties", new[] { "RatingId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Properties");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StarRating = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(),
                        PropertyTypeId = c.Int(),
                        PropertyName = c.String(nullable: false),
                        PropertyAdd = c.String(nullable: false),
                        PropertyDesc = c.String(),
                        RatingId = c.Int(),
                        Facilities = c.Boolean(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        Description = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Properties", "RatingId");
            CreateIndex("dbo.Properties", "PropertyTypeId");
            CreateIndex("dbo.Properties", "CityId");
            CreateIndex("dbo.Properties", "CountryId");
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Properties", "RatingId", "dbo.Ratings", "Id");
            AddForeignKey("dbo.Properties", "PropertyTypeId", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.Properties", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Properties", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
