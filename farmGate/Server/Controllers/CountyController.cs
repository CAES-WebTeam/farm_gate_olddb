using Microsoft.AspNetCore.Mvc;
using farmGate.Server.Data;
using farmGate.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using farmGate.Server.Services;

namespace farmGate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountyController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly CountyService _countyService;  

        public CountyController(MyDbContext context, CountyService countyService)  
        {
            _context = context;
            _countyService = countyService;  
        }

        [HttpGet]
        public IActionResult GetAllCounties()
        {
            return Ok(_context.Counties.ToList());
        }

        [HttpPost]
        public IActionResult AddCounty([FromBody] County county)
        {
            _context.Counties.Add(county);
            _context.SaveChanges();
            return Ok(county);
        }

        // Add this new method
        [HttpGet("ForLoggedInUser")]
        public async Task<IActionResult> GetCountyForLoggedInUser()
        {
            var county = await _countyService.GetCountyForLoggedInUser();
            if (county == null)
            {
                return NotFound();
            }
            return Ok(county);
        }
    }
}
