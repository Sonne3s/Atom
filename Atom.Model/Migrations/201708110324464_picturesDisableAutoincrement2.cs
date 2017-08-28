namespace Atom.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class picturesDisableAutoincrement2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
