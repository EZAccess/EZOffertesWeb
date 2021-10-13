using EZOffertes.Models;
using EZOffertes.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EZOffertes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersByCustomerController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrdersByCustomerController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{customerid:int}")]//("{customerid:int}/{orderid:int}")]
        public async Task<ActionResult<Order>> GetOrder(int customerid, int? orderid)
        {
            if (orderid == null)
            {
                try
                {
                    return Ok(await orderRepository.GetOrdersByCustomer(customerid));
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }
            }
            else
            {
                try
                {
                    var result = await orderRepository.GetOrder((int)orderid);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    if (result.CustomerId != customerid)
                    {
                        return NotFound();
                    }
                    return result;
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }
            }
        }

        [HttpPost("{customerid:int}")]
        public async Task<ActionResult<Order>> CreateOrder(int customerid, Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }
                if (order.CustomerId != customerid)
                {
                    return BadRequest();
                }

                var createdOrder = await orderRepository.AddOrder(order);
                return CreatedAtAction(nameof(GetOrder) , new { customerid = createdOrder.CustomerId, orderid = createdOrder.OrderId }, createdOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        //[HttpPut]
        //public async Task<ActionResult<Order>> UpdateOrder(Order order)
        //{
        //    try
        //    {
        //        var orderToUpdate = await orderRepository.GetOrder(order.OrderId);
        //        if (orderToUpdate == null)
        //        {
        //            return NotFound($"Order with id = {order.OrderId} not found");
        //        }

        //        return await orderRepository.UpdateOrder(order);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
        //    }
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Order>> DeleteOrder(int id)
        //{
        //    try
        //    {
        //        var orderToDelete = await orderRepository.GetOrder(id);
        //        if (orderToDelete == null)
        //        {
        //            return NotFound($"Order with id = {id} not found");
        //        }

        //        return await orderRepository.DeleteOrder(id);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
        //    }
        //}
    }
}
