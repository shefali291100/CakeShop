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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.orderService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.orderService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestDTO orderRequest)
        {
            var result = await this.orderService.Add(orderRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderRequestDTO v)
        {
            await this.orderService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.orderService.Delete(id);
                if (result) return Ok("Deleted");
                return NotFound("Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("byUserId/{UserId}")]
        public async Task<IActionResult> GetByUserId(int UserId)
        {
            var result = await this.orderService.GetByUserId(UserId);
            if (result is not null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
