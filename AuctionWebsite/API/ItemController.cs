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
    public class ItemController : ApiController
    {
        //Local variable to hold the access to the database via the generic repository
        private IGenericRepository _repo;
        //Constructor
        public ItemController(IGenericRepository repo)
        {
            _repo = repo;
        }

        public IHttpActionResult GetAllItems()
        {
            return Ok(_repo.Query<ItemModel>());
        }
        
        [Route("api/item/getItemsById/{id}")]
        public IHttpActionResult GetSingleItem(int id)
        {
            return Ok(_repo.Find<ItemModel>(id));
        }

        [Route("api/item/getBidsByItem/{id}")]
        public IHttpActionResult GetBidsByItem(int id)
        {
            var data = _repo.Query<ItemModel>().Where(i => i.Id == id).Include(i => i.Bids).FirstOrDefault();
            return Ok(data);
        }

        public IHttpActionResult PostItem(ItemModel item)
        {
            _repo.Add<ItemModel>(item);
            _repo.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteItem(int id)
        {
            _repo.Delete<ItemModel>(id);
            _repo.SaveChanges();
            return Ok();
        }

    }
}
