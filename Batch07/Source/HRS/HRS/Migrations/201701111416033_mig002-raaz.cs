namespace HRS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig002raaz : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Facilities");
            AlterColumn("dbo.Facilities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Facilities", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Facilities");
            AlterColumn("dbo.Facilities", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Facilities", "Id");
        }
    }
}
