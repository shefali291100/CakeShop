using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.BLL.Services;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService orderdetailService;

        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            this.orderdetailService = orderdetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.orderdetailService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.orderdetailService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailRequestDTO orderdetailRequest)
        {
            var result = await this.orderdetailService.Add(orderdetailRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailRequestDTO v)
        {
            await this.orderdetailService.Update(id, v);
            return Ok(v);
        }

        [HttpGet("byOrderId/{OrderId}")]
        public async Task<IActionResult> GetByOrderId(int OrderId)
        {
            var result = await this.orderdetailService.GetByOrderId(OrderId);
            if (result is not null)
            {
                return Ok(result);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.orderdetailService.Delete(id);
                if (result) return Ok("Deleted");
                return NotFound("Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
