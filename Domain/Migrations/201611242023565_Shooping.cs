namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shooping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoppings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShoppingTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingTypes", t => t.ShoppingTypeId, cascadeDelete: true)
                .Index(t => t.ShoppingTypeId);
            
            CreateTable(
                "dbo.ShoppingTypes",
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
            DropForeignKey("dbo.Shoppings", "ShoppingTypeId", "dbo.ShoppingTypes");
            DropForeignKey("dbo.ShoppingTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShoppingTypes", new[] { "CategoryId" });
            DropIndex("dbo.Shoppings", new[] { "ShoppingTypeId" });
            DropTable("dbo.ShoppingTypes");
            DropTable("dbo.Shoppings");
        }
    }
}
