namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IconType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "IconId", "dbo.Icons");
            DropIndex("dbo.Categories", new[] { "IconId" });
            AddColumn("dbo.Accommodations", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Icons", "IconName", c => c.String());
            AddColumn("dbo.Banks", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.FoodAndDrinks", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Healths", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Shoppings", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Sports", "IconId", c => c.Int(nullable: false));
            AddColumn("dbo.Touristics", "IconId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accommodations", "IconId");
            CreateIndex("dbo.Banks", "IconId");
            CreateIndex("dbo.Contacts", "IconId");
            CreateIndex("dbo.FoodAndDrinks", "IconId");
            CreateIndex("dbo.Healths", "IconId");
            CreateIndex("dbo.Shoppings", "IconId");
            CreateIndex("dbo.Sports", "IconId");
            CreateIndex("dbo.Touristics", "IconId");
            AddForeignKey("dbo.Accommodations", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Banks", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FoodAndDrinks", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Healths", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shoppings", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sports", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Touristics", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
            DropColumn("dbo.Categories", "IconId");
            DropColumn("dbo.Icons", "prefix");
            DropColumn("dbo.Icons", "suffix");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Icons", "suffix", c => c.String());
            AddColumn("dbo.Icons", "prefix", c => c.String());
            AddColumn("dbo.Categories", "IconId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Touristics", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Sports", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Shoppings", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Healths", "IconId", "dbo.Icons");
            DropForeignKey("dbo.FoodAndDrinks", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Contacts", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Banks", "IconId", "dbo.Icons");
            DropForeignKey("dbo.Accommodations", "IconId", "dbo.Icons");
            DropIndex("dbo.Touristics", new[] { "IconId" });
            DropIndex("dbo.Sports", new[] { "IconId" });
            DropIndex("dbo.Shoppings", new[] { "IconId" });
            DropIndex("dbo.Healths", new[] { "IconId" });
            DropIndex("dbo.FoodAndDrinks", new[] { "IconId" });
            DropIndex("dbo.Contacts", new[] { "IconId" });
            DropIndex("dbo.Banks", new[] { "IconId" });
            DropIndex("dbo.Accommodations", new[] { "IconId" });
            DropColumn("dbo.Touristics", "IconId");
            DropColumn("dbo.Sports", "IconId");
            DropColumn("dbo.Shoppings", "IconId");
            DropColumn("dbo.Healths", "IconId");
            DropColumn("dbo.FoodAndDrinks", "IconId");
            DropColumn("dbo.Contacts", "IconId");
            DropColumn("dbo.Banks", "IconId");
            DropColumn("dbo.Icons", "IconName");
            DropColumn("dbo.Accommodations", "IconId");
            CreateIndex("dbo.Categories", "IconId");
            AddForeignKey("dbo.Categories", "IconId", "dbo.Icons", "Id", cascadeDelete: true);
        }
    }
}
