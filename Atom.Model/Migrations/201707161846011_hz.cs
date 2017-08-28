namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hz : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Image", c => c.String());
            AlterColumn("dbo.Articles", "Name", c => c.String());
        }
    }
}
