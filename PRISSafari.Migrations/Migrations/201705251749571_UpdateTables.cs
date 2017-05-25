namespace PRISSafari.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auction", "AuctionWon", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comment", "UserRating", c => c.Int(nullable: false));
            DropColumn("dbo.User", "UserRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserRating", c => c.Int(nullable: false));
            DropColumn("dbo.Comment", "UserRating");
            DropColumn("dbo.Auction", "AuctionWon");
        }
    }
}
