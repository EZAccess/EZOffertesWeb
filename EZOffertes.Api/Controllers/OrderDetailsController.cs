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
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        [HttpGet("{orderid:int}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int orderid, int? orderdetailid)
        {
            try
            {
                if (orderdetailid == null)
                {
                    return Ok(await orderDetailRepository.GetOrderDetailsByOrder(orderid));
                }
                if (orderdetailid == 0)
                {
                    return BadRequest();
                }
                var result = await orderDetailRepository.GetOrderDetail((int)orderdetailid);
                if (result == null)
                {
                    return NotFound();
                }
                if (result.OrderId != orderid)
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

        [HttpPost("{orderid:int}")]
        public async Task<ActionResult<OrderDetail>> CreateOrderDetail(int orderid, OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail == null)
                {
                    return BadRequest();
                }

                orderDetail.OrderId = orderid;
                var createdOrderDetail = await orderDetailRepository.AddOrderDetail(orderDetail);
                return CreatedAtAction(nameof(GetOrderDetail), new { orderid = createdOrderDetail.OrderId }, createdOrderDetail);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut("{orderid:int}")]
        public async Task<ActionResult<OrderDetail>> UpdateOrderDetail(int orderid, OrderDetail orderDetail)
        {
            try
            {
                var orderDetailToUpdate = await orderDetailRepository.GetOrderDetail(orderDetail.OrderDetailId);
                if (orderDetailToUpdate == null)
                {
                    return NotFound($"OrderDetail with id = {orderDetail.OrderDetailId} not found");
                }
                if (orderDetailToUpdate.OrderId != orderid)
                {
                    return NotFound($"OrderDetail with id = {orderDetail.OrderDetailId} not found");
                }

                return await orderDetailRepository.UpdateOrderDetail(orderDetail);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{orderid:int}/{orderdetailid:int}")]
        public async Task<ActionResult<OrderDetail>> DeleteOrderDetail(int orderid, int orderdetailid)
        {
            try
            {
                var orderDetailToDelete = await orderDetailRepository.GetOrderDetail(orderdetailid);
                if (orderDetailToDelete == null)
                {
                    return NotFound($"OrderDetail with id = {orderdetailid} not found");
                }
                if (orderDetailToDelete.OrderId != orderid)
                {
                    return NotFound($"OrderDetail with id = {orderdetailid} not found");
                }

                return await orderDetailRepository.DeleteOrderDetail(orderdetailid);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
