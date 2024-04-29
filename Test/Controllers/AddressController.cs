using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.BLL.Services;
using Test.DAL.Entities;
using Test.DAL.Repositories;
using Test.BLL.Services;
namespace Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.addressService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.addressService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddressRequestDTO addressRequest)
        {
            var result = await this.addressService.Add(addressRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressRequestDTO v)
        {
            await this.addressService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.addressService.Delete(id);
                if (result) return Ok("Deleted");
                return NotFound("Not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("byCustomerId/{CustomerId}")]
        public async Task<IActionResult> GetByCustomerId(int CustomerId)
        {
            var result = await this.addressService.GetByCustomerId(CustomerId);
            if (result is not null)
            {
                return Ok(result);
            }
            return null;
        }
    }

}