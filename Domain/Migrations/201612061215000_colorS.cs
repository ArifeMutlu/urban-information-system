namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colorS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Color", c => c.String());
            DropColumn("dbo.Icons", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Icons", "Color", c => c.String());
            DropColumn("dbo.Categories", "Color");
        }
    }
}
