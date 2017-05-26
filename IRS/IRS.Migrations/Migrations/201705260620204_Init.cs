namespace IRS.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 60, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 60, storeType: "nvarchar"),
                        FullName = c.String(unicode: false),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        PasswordSalt = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        RoleId = c.Byte(nullable: false),
                        RowVersion = c.DateTime(nullable: false, precision: 6, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("UserRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "AuctionItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Condition = c.String(unicode: false),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        UserId = c.Int(nullable: false),
                        AuctionItemCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AuctionItemCategory", t => t.AuctionItemCategoryId, cascadeDelete: true)
                .ForeignKey("User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionItemCategoryId);
            
            CreateTable(
                "AuctionItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Auction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        AuctionItemId = c.Int(nullable: false),
                        AuctionWon = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AuctionItem", t => t.AuctionItemId, cascadeDelete: true)
                .ForeignKey("User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionItemId);
            
            CreateTable(
                "Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false),
                        UserRating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedByUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("User", t => t.UserId)
                .ForeignKey("User", t => t.CreatedByUserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedByUserId);
            
            CreateTable(
                "UserRole",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Description = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                ;
            
        }
        
        public override void Down()
        {
            DropForeignKey("User", "RoleId", "UserRole");
            DropForeignKey("Comment", "CreatedByUserId", "User");
            DropForeignKey("Comment", "UserId", "User");
            DropForeignKey("Auction", "UserId", "User");
            DropForeignKey("AuctionItem", "UserId", "User");
            DropForeignKey("Auction", "AuctionItemId", "AuctionItem");
            DropForeignKey("AuctionItem", "AuctionItemCategoryId", "AuctionItemCategory");
            DropIndex("Comment", new[] { "CreatedByUserId" });
            DropIndex("Comment", new[] { "UserId" });
            DropIndex("Auction", new[] { "AuctionItemId" });
            DropIndex("Auction", new[] { "UserId" });
            DropIndex("AuctionItem", new[] { "AuctionItemCategoryId" });
            DropIndex("AuctionItem", new[] { "UserId" });
            DropIndex("User", new[] { "RoleId" });
            DropTable("UserRole");
            DropTable("Comment");
            DropTable("Auction");
            DropTable("AuctionItemCategory");
            DropTable("AuctionItem");
            DropTable("User");
        }
    }
}
