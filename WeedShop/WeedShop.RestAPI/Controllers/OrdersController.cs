using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeedShop.Core.ApplicationService;
using WeedShop.Core.Entity;

namespace WeedShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderServ;

        public OrdersController(IOrderService orderServ)
        {
            _orderServ = orderServ;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return Ok(_orderServ.GetOrders());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return Ok(_orderServ.GetOrder(id));
        }

        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            return Ok(_orderServ.AddOrder(order));
        }

        [HttpPut("{id}")]
        public ActionResult<Order> Put([FromBody] Order order)
        {
            return Ok(_orderServ.UpdateOrder(order));
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(Order order)
        {
            return Ok(_orderServ.DeleteOrder(order));
        }





    }
}