namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Touristic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Touristics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TouristicTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TouristicTypes", t => t.TouristicTypeId, cascadeDelete: true)
                .Index(t => t.TouristicTypeId);
            
            CreateTable(
                "dbo.TouristicTypes",
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
            DropForeignKey("dbo.Touristics", "TouristicTypeId", "dbo.TouristicTypes");
            DropForeignKey("dbo.TouristicTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TouristicTypes", new[] { "CategoryId" });
            DropIndex("dbo.Touristics", new[] { "TouristicTypeId" });
            DropTable("dbo.TouristicTypes");
            DropTable("dbo.Touristics");
        }
    }
}
