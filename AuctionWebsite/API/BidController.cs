using AuctionWebsite.Models;
using AuctionWebsite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuctionWebsite.API
{
    public class BidController : ApiController
    {
        //Local variable to hold the access to the database via the generic repository
        private IGenericRepository _repo;
        //Constructor
        public BidController(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IHttpActionResult GetAllBids()
        {
            return Ok(_repo.Query<BidModel>());
        }

        public IHttpActionResult GetSingleBid(int id)
        {
            return Ok(_repo.Find<BidModel>(id));
        }

        public IHttpActionResult PostItem(BidModel bid)
        {
            _repo.Add<BidModel>(bid);
            _repo.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteBid(int id)
        {
            _repo.Delete<BidModel>(id);
            _repo.SaveChanges();
            return Ok();
        }
    }
}
