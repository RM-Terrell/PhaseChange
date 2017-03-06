//Fast and dirty migrations. Woops. 
//So i need to add the dbset reference in identity models first or identity framework just sits there and drools when i do migrations around that data.
//Mosh said this and everything in the tutorial and I totally spaced it. Lesson learned, always add refernce to be included in migrations.

namespace PhaseChange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlsFixPls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
        }
    }
}
