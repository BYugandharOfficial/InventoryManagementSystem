namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Suppliers2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CategoryName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Suppliers", "ProductName", c => c.String());
            DropColumn("dbo.Suppliers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Suppliers", "ProductName");
            DropColumn("dbo.Suppliers", "CategoryName");
        }
    }
}
