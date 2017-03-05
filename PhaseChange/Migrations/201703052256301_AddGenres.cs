//Originally had this done before the "PlsFix" migration which properly creates the tables.
//Turns out you cant INSERT INTO a table if it hasnt been made yet....who would have thought.

namespace PhaseChange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'RPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'FPS')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Platformer')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Survival')");
        }
        
        public override void Down()
        {
        }
    }
}
