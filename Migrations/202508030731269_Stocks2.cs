namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stocks2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "StockMovements", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "StockMovements");
        }
    }
}
