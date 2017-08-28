namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picturesDisableAutoincrement : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pictures", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pictures", "Id");
        }
    }
}
