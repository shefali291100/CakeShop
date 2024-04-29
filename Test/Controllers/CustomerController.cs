using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.BLL.Services;
using Test.BLL.Services.ICustomerService;
using Test.DAL.Entities;
using Test.DAL.Repositories;

namespace Test.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.customerService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.customerService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestDTO customerRequest)
        {
            var result = await this.customerService.Add(customerRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerRequestDTO v)
        {
            await this.customerService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.customerService.Delete(id);
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
