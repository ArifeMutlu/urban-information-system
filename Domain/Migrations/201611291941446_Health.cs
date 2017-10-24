namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Health : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Healths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HealthTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HealthTypes", t => t.HealthTypeId, cascadeDelete: true)
                .Index(t => t.HealthTypeId);
            
            CreateTable(
                "dbo.HealthTypes",
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
            DropForeignKey("dbo.Healths", "HealthTypeId", "dbo.HealthTypes");
            DropForeignKey("dbo.HealthTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.HealthTypes", new[] { "CategoryId" });
            DropIndex("dbo.Healths", new[] { "HealthTypeId" });
            DropTable("dbo.HealthTypes");
            DropTable("dbo.Healths");
        }
    }
}
