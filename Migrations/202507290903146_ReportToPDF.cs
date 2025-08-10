namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportToPDF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportToPDFs",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportToPDFs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ReportToPDFs", new[] { "CustomerId" });
            DropTable("dbo.ReportToPDFs");
        }
    }
}
