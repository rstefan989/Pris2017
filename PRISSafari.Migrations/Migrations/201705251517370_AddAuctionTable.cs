namespace PRISSafari.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuctionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        AuctionItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuctionItem", t => t.AuctionItemId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AuctionItemId);
            
            AddColumn("dbo.User", "UserRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auction", "UserId", "dbo.User");
            DropForeignKey("dbo.Auction", "AuctionItemId", "dbo.AuctionItem");
            DropIndex("dbo.Auction", new[] { "AuctionItemId" });
            DropIndex("dbo.Auction", new[] { "UserId" });
            DropColumn("dbo.User", "UserRating");
            DropTable("dbo.Auction");
        }
    }
}
