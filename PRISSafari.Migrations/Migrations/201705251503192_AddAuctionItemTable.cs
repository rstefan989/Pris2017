namespace PRISSafari.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuctionItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(maxLength: 200),
                        Condition = c.String(nullable: false, maxLength: 200),
                        StartingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuctionItem", "UserId", "dbo.User");
            DropIndex("dbo.AuctionItem", new[] { "UserId" });
            DropTable("dbo.AuctionItem");
        }
    }
}
