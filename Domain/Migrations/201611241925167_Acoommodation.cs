namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Acoommodation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accommodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccommodationTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                        Star = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccommodationTypes", t => t.AccommodationTypeId, cascadeDelete: true)
                .Index(t => t.AccommodationTypeId);
            
            CreateTable(
                "dbo.AccommodationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accommodations", "AccommodationTypeId", "dbo.AccommodationTypes");
            DropForeignKey("dbo.AccommodationTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AccommodationTypes", new[] { "CategoryId" });
            DropIndex("dbo.Accommodations", new[] { "AccommodationTypeId" });
            DropTable("dbo.AccommodationTypes");
            DropTable("dbo.Accommodations");
        }
    }
}
