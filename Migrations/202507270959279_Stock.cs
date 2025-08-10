namespace Inventory_Mnagement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ContactPerson = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        GSTNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateIndex("dbo.Stocks", "SupplierId");
            AddForeignKey("dbo.Stocks", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Stocks", new[] { "SupplierId" });
            DropTable("dbo.Suppliers");
        }
    }
}
