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
            List<Weed> weeds = new List<Weed>()
            {
                new Weed{Id = 1, Name = "Weed"},
                new Weed{Id = 2, Name = "Cannabios"},
                new Weed{Id = 3, Name = "Khuez"},
                new Weed{Id = 4, Name = "Krezi mod"},
                new Weed{Id = 5, Name = "Forhni Feks"},
                new Weed{Id = 6, Name = "Laco"},
                new Weed{Id = 7, Name = "Hvad hedder weed?"},
                new Weed{Id = 8, Name = "KundeMedKre"},
                new Weed{Id = 9, Name = "Ku'"}
            };
            return Ok(weeds);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Weed> Get(int id)
        {
            return Ok(_weedServ.GetWeed(id))
                
                ;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Weed> Post([FromBody] Weed weed)
        {
            return Ok(_weedServ.CreateWeed(weed));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Weed> Put(int id, [FromBody] Weed weed)
        {
            return Ok(_weedServ.UpdateWeed(weed));
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