namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
