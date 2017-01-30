namespace ChatardApp.Migrations
{
    using System.Data.Entity.Migrations;

    public class PopulateEventsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EVENTS (Id, Name) Values (1, 'Practice')");
            Sql("INSERT INTO EVENTS (Id, Name) Values (2, 'Game')");
            Sql("INSERT INTO EVENTS (Id, Name) Values (3, 'Event')");
        }

        public override void Down()
        {
            Sql("DELETE FROM EVENTS WHERE Id in (1, 2, 3)");
        }
    }
}
