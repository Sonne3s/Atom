namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Image = c.String(),
                        Content = c.String(),
                        Publish = c.Boolean(nullable: false),
                        Published = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        First = c.String(),
                        Middle = c.String(),
                        Last = c.String(),
                        Phone = c.String(),
                        Position = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        PersonID = c.Int(nullable: false),
                        JudoRank = c.Int(nullable: false),
                        SamboRank = c.Int(nullable: false),
                        ARBRank = c.Int(nullable: false),
                        RelativeID1 = c.Int(nullable: false),
                        Degree1 = c.Int(nullable: false),
                        RelativeID2 = c.Int(nullable: false),
                        Degree2 = c.Int(nullable: false),
                        RelativeID3 = c.Int(nullable: false),
                        Degree3 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.People", t => t.PersonID)
                .Index(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "PersonID", "dbo.People");
            DropIndex("dbo.Students", new[] { "PersonID" });
            DropTable("dbo.Students");
            DropTable("dbo.People");
            DropTable("dbo.Articles");
        }
    }
}
