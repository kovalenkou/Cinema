namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateSessioninSaleRep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesRep", "DateSale", c => c.DateTime(nullable: false));
            AddColumn("dbo.SalesRep", "SessionId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesRep", "SessionId");
            AddForeignKey("dbo.SalesRep", "SessionId", "dbo.Session", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesRep", "SessionId", "dbo.Session");
            DropIndex("dbo.SalesRep", new[] { "SessionId" });
            DropColumn("dbo.SalesRep", "SessionId");
            DropColumn("dbo.SalesRep", "DateSale");
        }
    }
}
