using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionWebsite.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The item name is required")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal MinimumBid { get; set; }
        [Range(0, 10)]
        public int NumberOfBids { get; set; }
        public ICollection<BidModel> Bids { get; set; }

    }
}