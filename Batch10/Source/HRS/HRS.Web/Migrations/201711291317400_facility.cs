namespace HRS.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class facility : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoomFacilities", newName: "Facilities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Facilities", newName: "RoomFacilities");
        }
    }
}
