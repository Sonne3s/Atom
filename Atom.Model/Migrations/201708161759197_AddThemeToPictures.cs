namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThemeToPictures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Theme", c => c.String());
            DropColumn("dbo.Pictures", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Name", c => c.String());
            DropColumn("dbo.Pictures", "Theme");
        }
    }
}
