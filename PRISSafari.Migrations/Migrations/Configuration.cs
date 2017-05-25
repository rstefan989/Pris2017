namespace PRISSafari.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Domain.Entities;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<PRISSafari.Repositories.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            List<User> users = new List<User>();
            users.Add(
                        new User
                        {
                            Id = 1,
                            FirstName = "Tamara ",
                            LastName = "Novakovic",
                            Email = "test@mail.com"
                        });
            users.Add(
                        new User
                        {
                            Id = 2,
                            FirstName = "Stefan ",
                            LastName = "Radosavljevic",
                            Email = "test1@mail.com"
                        }
                        );
            users.Add(
                        new User
                        {
                            Id = 3,
                            FirstName = "Nela ",
                            LastName = "Dokmanovic",
                            Email = "test2@mail.com"
                        }
                        );
            foreach (var user in users)
            {
                context.Set<User>().Add(user);
            }

            List<AuctionItemCategory> auctionItemCategories = new List<AuctionItemCategory>();
            auctionItemCategories.Add(
                        new AuctionItemCategory
                        {
                            Id = 1,
                            Name = "Namestaj"
                        });
            auctionItemCategories.Add(
                        new AuctionItemCategory
                        {
                            Id = 2,
                            Name = "Umetnicka dela"
                        }
                        );
            foreach (var auctionItemCategory in auctionItemCategories)
            {
                context.Set<AuctionItemCategory>().Add(auctionItemCategory);
            }

            List<AuctionItem> auctionItems = new List<AuctionItem>();
            auctionItems.Add(
                            new AuctionItem
                            {
                                Id = 1,
                                Name = "Umetnicka slika",
                                Description = "Delo Slobodana Spasojevica, Godina 2017",
                                Condition = "U odlicnom stanju, nema nikakvih ostecenja",
                                StartingPrice = 100,
                                EndDate = new DateTime(2018, 1, 1),
                                UserId = 1,
                                AuctionItemCategoryId = 2
                            });
            auctionItems.Add(
                            new AuctionItem
                            {
                                Id = 2,
                                Name = "Toaletni stocic",
                                Description = "Drveni stocic, Godina 2015",
                                Condition = "U odlicnom stanju, nema nikakvih ostecenja",
                                StartingPrice = 20,
                                EndDate = new DateTime(2018, 10, 1),
                                UserId = 2,
                                AuctionItemCategoryId = 1
                            }
                            );
            foreach (var auctionItem in auctionItems)
            {
                context.Set<AuctionItem>().Add(auctionItem);
            }

            List<Auction> auctions = new List<Auction>();
            auctions.Add(
                        new Auction
                        {
                            Id = 1,
                            Price = 125,
                            AuctionItemId = 1,
                            UserId = 2
                        });
            auctions.Add(
                        new Auction
                        {
                            Id = 2,
                            Price = 23,
                            AuctionItemId = 2,
                            UserId = 1
                        }
                        );
            auctions.Add(
                       new Auction
                       {
                           Id = 3,
                           Price = 31,
                           AuctionItemId = 2,
                           UserId = 3
                       }
                       );
            foreach (var auction in auctions)
            {
                context.Set<Auction>().Add(auction);
            }

            context.SaveChanges();
        }
    }
}
