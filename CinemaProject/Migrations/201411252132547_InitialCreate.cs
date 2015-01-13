namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChairType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowNumber = c.Int(nullable: false),
                        LocNumber = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                        ChairTypeId = c.Int(nullable: false),
                        Active = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChairType", t => t.ChairTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Hall", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.ChairTypeId);
            
            CreateTable(
                "dbo.SalesRep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallId = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                        LocNumber = c.Int(nullable: false),
                        Cash = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hall", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Schema",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Film", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Hall", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Session", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.SessionId)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        ChairTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChairType", t => t.ChairTypeId, cascadeDelete: true)
                .Index(t => t.ChairTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "ChairTypeId", "dbo.ChairType");
            DropForeignKey("dbo.Schema", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Schema", "HallId", "dbo.Hall");
            DropForeignKey("dbo.Schema", "FilmId", "dbo.Film");
            DropForeignKey("dbo.SalesRep", "HallId", "dbo.Hall");
            DropForeignKey("dbo.Location", "HallId", "dbo.Hall");
            DropForeignKey("dbo.Location", "ChairTypeId", "dbo.ChairType");
            DropIndex("dbo.Ticket", new[] { "ChairTypeId" });
            DropIndex("dbo.Schema", new[] { "FilmId" });
            DropIndex("dbo.Schema", new[] { "SessionId" });
            DropIndex("dbo.Schema", new[] { "HallId" });
            DropIndex("dbo.SalesRep", new[] { "HallId" });
            DropIndex("dbo.Location", new[] { "ChairTypeId" });
            DropIndex("dbo.Location", new[] { "HallId" });
            DropTable("dbo.Ticket");
            DropTable("dbo.Session");
            DropTable("dbo.Schema");
            DropTable("dbo.SalesRep");
            DropTable("dbo.Location");
            DropTable("dbo.Hall");
            DropTable("dbo.Film");
            DropTable("dbo.ChairType");
        }
    }
}
