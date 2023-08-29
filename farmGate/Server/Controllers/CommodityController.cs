using farmGate.Server.Services;
using farmGate.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace farmGate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly CommodityService _commodityService;

        public CommodityController(CommodityService commodityService)
        {
            _commodityService = commodityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commodityService.GetAllCommoditiesAsync());
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            return Ok(await _commodityService.GetCommoditiesByCategoryIdAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> AddCommodity([FromBody] Commodity newCommodity)
        {
            var addedCommodity = await _commodityService.AddCommodityAsync(newCommodity);
            if (addedCommodity != null)
            {
                return Ok(addedCommodity);
            }
            else
            {
                // Handle error here, for example:
                return BadRequest("Could not add commodity");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommodity(int id)
        {
            bool success = await _commodityService.DeleteCommodityAsync(id);
            if (success)
            {
                return Ok();  // 200 OK
            }
            else
            {
                return NotFound();  // 404 Not Found
            }
        }
    }
}
