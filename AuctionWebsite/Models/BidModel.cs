using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionWebsite.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Your name is required")]
        public string BidderName { get; set; }
        [Required(ErrorMessage = "A bid amount is required")]
        public decimal BidAmount { get; set; }

    }
}