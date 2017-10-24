namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HealthType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Healths", "Description", c => c.String());
            AddColumn("dbo.Healths", "Url", c => c.String());
            AddColumn("dbo.Healths", "Lat", c => c.String());
            AddColumn("dbo.Healths", "Long", c => c.String());
            AddColumn("dbo.Healths", "Phone", c => c.String());
            AddColumn("dbo.Healths", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Healths", "Picture");
            DropColumn("dbo.Healths", "Phone");
            DropColumn("dbo.Healths", "Long");
            DropColumn("dbo.Healths", "Lat");
            DropColumn("dbo.Healths", "Url");
            DropColumn("dbo.Healths", "Description");
        }
    }
}
