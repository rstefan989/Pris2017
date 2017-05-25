namespace PRISSafari.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuctionItemCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionItemCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AuctionItem", "AuctionItemCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.AuctionItem", "AuctionItemCategoryId");
            AddForeignKey("dbo.AuctionItem", "AuctionItemCategoryId", "dbo.AuctionItemCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionItem", "AuctionItemCategoryId", "dbo.AuctionItemCategory");
            DropIndex("dbo.AuctionItem", new[] { "AuctionItemCategoryId" });
            DropColumn("dbo.AuctionItem", "AuctionItemCategoryId");
            DropTable("dbo.AuctionItemCategory");
        }
    }
}
