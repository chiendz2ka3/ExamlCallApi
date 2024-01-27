using ExamAPI.Entity;
using Examl.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ExamAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class ordercontroller : ControllerBase
    {
        private readonly DbContextorder _dbcontext;

        public ordercontroller(DbContextorder dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> placeorder([FromBody] Order orderdto)
        {
            var order = new Order()
            {
                ItemName = orderdto.ItemName,
                ItemQty = orderdto.ItemQty,
                OrderDelivery = orderdto.OrderDelivery,
                OrderAddress = orderdto.OrderAddress,
                PhoneNumber = orderdto.PhoneNumber
            };

            _dbcontext.Orders.Add(order);
            await _dbcontext.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPut("{orderid}")]
        public async Task<IActionResult> editorder(int orderid, [FromBody] OrderEditDto ordereditdto)
        {
            var order = await _dbcontext.Orders.FindAsync(orderid);

            if (order == null)
            {
                return NotFound();
            }

            order.OrderDelivery = ordereditdto.OrderDelivery;
            order.OrderAddress = ordereditdto.OrderAddress;

            await _dbcontext.SaveChangesAsync();

            return Ok(order);
        }
    }
}