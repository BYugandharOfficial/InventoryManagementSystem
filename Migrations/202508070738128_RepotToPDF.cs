namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepotToPDF : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReportToPDFs", "CustomerId");
            AddForeignKey("dbo.ReportToPDFs", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.ReportToPDFs", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportToPDFs", "FullName", c => c.String());
            DropForeignKey("dbo.ReportToPDFs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ReportToPDFs", new[] { "CustomerId" });
        }
    }
}
