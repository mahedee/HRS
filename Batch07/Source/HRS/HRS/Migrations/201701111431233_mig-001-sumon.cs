namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig001sumon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false, maxLength: 20),
                        Phone = c.String(maxLength: 20),
                        Fax = c.String(maxLength: 50),
                        Website = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        LogoURL = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hotels");
        }
    }
}
