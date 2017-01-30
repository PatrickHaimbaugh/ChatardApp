namespace ChatardApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToMeetings : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meetings", name: "Coach_Id", newName: "CoachId");
            RenameColumn(table: "dbo.Meetings", name: "Event_Id", newName: "EventId");
            RenameIndex(table: "dbo.Meetings", name: "IX_Coach_Id", newName: "IX_CoachId");
            RenameIndex(table: "dbo.Meetings", name: "IX_Event_Id", newName: "IX_EventId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meetings", name: "IX_EventId", newName: "IX_Event_Id");
            RenameIndex(table: "dbo.Meetings", name: "IX_CoachId", newName: "IX_Coach_Id");
            RenameColumn(table: "dbo.Meetings", name: "EventId", newName: "Event_Id");
            RenameColumn(table: "dbo.Meetings", name: "CoachId", newName: "Coach_Id");
        }
    }
}
