namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.ContactTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ContactTypes", new[] { "CategoryId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
        }
    }
}
