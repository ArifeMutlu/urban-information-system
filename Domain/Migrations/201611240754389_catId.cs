namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodDrinkTypes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.FoodDrinkTypes", new[] { "Category_Id" });
            RenameColumn(table: "dbo.FoodDrinkTypes", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.FoodDrinkTypes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.FoodDrinkTypes", "CategoryId");
            AddForeignKey("dbo.FoodDrinkTypes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.FoodDrinkTypes", "CatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodDrinkTypes", "CatId", c => c.Int(nullable: false));
            DropForeignKey("dbo.FoodDrinkTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FoodDrinkTypes", new[] { "CategoryId" });
            AlterColumn("dbo.FoodDrinkTypes", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.FoodDrinkTypes", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.FoodDrinkTypes", "Category_Id");
            AddForeignKey("dbo.FoodDrinkTypes", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
