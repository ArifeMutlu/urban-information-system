namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IconId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Icons", t => t.IconId, cascadeDelete: true)
                .Index(t => t.IconId);
            
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        prefix = c.String(),
                        suffix = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodAndDrinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Adress = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodDrinkTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.FoodDrinkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatId = c.Int(nullable: false),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodAndDrinks", "TypeId", "dbo.FoodDrinkTypes");
            DropForeignKey("dbo.FoodDrinkTypes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "IconId", "dbo.Icons");
            DropIndex("dbo.FoodDrinkTypes", new[] { "Category_Id" });
            DropIndex("dbo.FoodAndDrinks", new[] { "TypeId" });
            DropIndex("dbo.Categories", new[] { "IconId" });
            DropTable("dbo.FoodDrinkTypes");
            DropTable("dbo.FoodAndDrinks");
            DropTable("dbo.Icons");
            DropTable("dbo.Categories");
        }
    }
}
