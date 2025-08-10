namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Category", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "Category");
        }
    }
}
