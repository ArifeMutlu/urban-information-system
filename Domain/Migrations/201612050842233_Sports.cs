namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SportTypesId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportTypes", t => t.SportTypesId, cascadeDelete: true)
                .Index(t => t.SportTypesId);
            
            CreateTable(
                "dbo.SportTypes",
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
            DropForeignKey("dbo.Sports", "SportTypesId", "dbo.SportTypes");
            DropForeignKey("dbo.SportTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SportTypes", new[] { "CategoryId" });
            DropIndex("dbo.Sports", new[] { "SportTypesId" });
            DropTable("dbo.SportTypes");
            DropTable("dbo.Sports");
        }
    }
}
