using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.BLL.DTOs.Request;
using Test.BLL.DTOs.Response;
using Test.DAL.Entities;
using Test.DAL.Repositories;
using Test.BLL.Services;

namespace Test.Controllers
{
 

    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly ICakeService cakeService;

        public CakeController(ICakeService cakeService)
        {
            this.cakeService = cakeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.cakeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetId(int id)
        {
            var result = await this.cakeService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CakeRequestDTO cakeRequest)
        {
            var result = await this.cakeService.Add(cakeRequest);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCake(int id, CakeRequestDTO v)
        {
            await this.cakeService.Update(id, v);
            return Ok(v);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.cakeService.Delete(id);
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
