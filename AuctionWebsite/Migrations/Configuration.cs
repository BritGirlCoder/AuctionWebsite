namespace AuctionWebsite.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuctionWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuctionWebsite.Models.ApplicationDbContext context)
        {
            ItemModel[] items = new ItemModel[] {
                new ItemModel {
                     ItemName = "Laptop",
                     ItemDescription = "HP8530p",
                     MinimumBid = 575m,
                     NumberOfBids = 10,
                     Bids = new List<BidModel> {
                         new BidModel { BidAmount = 525m, BidderName = "Courtney Austin" },
                         new BidModel { BidAmount = 550m, BidderName = "Matt Collins"},
                         new BidModel { BidAmount = 575m, BidderName = "Austin Wilson"}
                       }
                },
                new ItemModel {
                     ItemName = "Peanut Butter",
                     ItemDescription = "Slightly used Jiffy Creamy Peanut Butter",
                     MinimumBid = 7m,
                     NumberOfBids = 10,
                     Bids = new List<BidModel> {
                         new BidModel { BidAmount = 5m, BidderName = "Courtney Austin" },
                         new BidModel { BidAmount = 6m, BidderName = "Matt Collins"},
                         new BidModel { BidAmount = 7m, BidderName = "Austin Wilson"}
                       }
            },
                new ItemModel {
                     ItemName = "Tesla",
                     ItemDescription = "Mint condition Tesla S",
                     MinimumBid = 70000m,
                     NumberOfBids = 10,
                     Bids = new List<BidModel> {
                         new BidModel { BidAmount = 50000m, BidderName = "Courtney Austin" },
                         new BidModel { BidAmount = 60000m, BidderName = "Matt Collins"},
                         new BidModel { BidAmount = 70000m, BidderName = "Debbie Westwood"}
                       }
            },
        };

            context.Items.AddOrUpdate(i => i.ItemName, items);

    }//seed class
    }//configuration class
} //namespace
