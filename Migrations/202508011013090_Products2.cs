namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Products2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            DropColumn("dbo.Products", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ProductName");
        }
    }
}
