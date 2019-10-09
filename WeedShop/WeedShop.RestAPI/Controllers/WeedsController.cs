using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedShop.Core.DomainService;
using WeedShop.Core.Entity;

namespace WeedShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeedsController : ControllerBase
    {
        private IWeedService _weedServ;
        public WeedsController(IWeedService weedServ)
        {
            _weedServ = weedServ;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<Weed>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
                {
                    return Ok(_weedServ.GetWeeds(filter));
                }
                else
                {
                    return Ok(_weedServ.GetWeeds(null));
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Weed> Get(int id)
        {
            try
            {
                var weed = _weedServ.GetWeed(id);
                if (weed == null)
                {
                    return BadRequest("Could not find the specific weed");
                }
                else
                {
                    return Ok(weed);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Weed> Post([FromBody] Weed weed)
        {
            try
            {
                return Ok(_weedServ.CreateWeed(weed));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Weed> Put(int id, [FromBody] Weed weed)
        {
            if (id != weed.Id)
            {
                return BadRequest("Id's are not equal. Could not update");
            }else
            {
                return Ok(_weedServ.UpdateWeed(weed));
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Weed> Delete(int id)
        {
            Weed weed = _weedServ.GetWeed(id);
            if (weed == null)
            {
                return BadRequest("Could not find the specific weed to delete");
            }else
            {
                return Ok(_weedServ.DeleteWeed(weed));
            }
        }
    }
}