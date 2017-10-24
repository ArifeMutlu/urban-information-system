namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bank : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BankTypeId = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        Lat = c.String(),
                        Long = c.String(),
                        Phone = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankTypes", t => t.BankTypeId, cascadeDelete: true)
                .Index(t => t.BankTypeId);
            
            CreateTable(
                "dbo.BankTypes",
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
            DropForeignKey("dbo.Banks", "BankTypeId", "dbo.BankTypes");
            DropForeignKey("dbo.BankTypes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BankTypes", new[] { "CategoryId" });
            DropIndex("dbo.Banks", new[] { "BankTypeId" });
            DropTable("dbo.BankTypes");
            DropTable("dbo.Banks");
        }
    }
}
