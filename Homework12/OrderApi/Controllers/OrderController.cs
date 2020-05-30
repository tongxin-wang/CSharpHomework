using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly OrderContext orderDb;

        //构造函数把OrderContext 作为参数，Asp.net core 框架可以自动注入OrderContext对象
        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        // GET: api/order/{id}  id为路径参数
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orderDb.Orders.FirstOrDefault(p => p.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // GET: api/order
        // GET: api/order/query?customerName=客户名&&address=配送地址
        [HttpGet("query")]
        public ActionResult<List<Order>> GetOrders(string customerName, string address)
        {
            var query = Query(customerName, address);
            return query.ToList();
        }
        
        private IQueryable<Order> Query(string customerName, string address)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (customerName != null)
            {
                query = query.Where(p => p.CustomerName.Contains(customerName));
            }
            if (address != null)
            {
                query = query.Where(p => p.Address == address);
            }
            return query;
        }


        // POST: api/order
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(p => p.OrderId == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

    }
}
