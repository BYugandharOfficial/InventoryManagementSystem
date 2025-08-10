namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportToPDF1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportToPDFs", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.ReportToPDFs", "CategoryName", c => c.String());
            AddColumn("dbo.ReportToPDFs", "ProductName", c => c.String());
            DropColumn("dbo.ReportToPDFs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportToPDFs", "Name", c => c.String());
            DropColumn("dbo.ReportToPDFs", "ProductName");
            DropColumn("dbo.ReportToPDFs", "CategoryName");
            DropColumn("dbo.ReportToPDFs", "CategoryId");
        }
    }
}
