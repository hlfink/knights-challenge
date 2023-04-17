using Knights.Challenge.Core.Application.Contracts;
using Knights.Challenge.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Knights.Challenge.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/knight")]
    [ApiVersion("1.0")]
    [ApiController]
    public class KnightController : Controller
    {
        private IKnightService knightService;
        public KnightController(IKnightService knightService)
        {
            this.knightService = knightService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(KnightRequest knightRequest)
        {
            await knightService.CreateAsync(knightRequest);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await knightService.GetAllAsync();
            return Ok(response);
        }
        [HttpGet("{id}/id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = await knightService.GetByIdAsync(id);
            
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [HttpPut("{id}/id/{nickName}/nickname")]
        public async Task<IActionResult> UpdateAsync(Guid id, string nickName)
        {
            await knightService.UpdateAsync(id, nickName);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await knightService.DeleteAsync(id);
            return Ok();
        }
    }
}
