using Microsoft.AspNetCore.Mvc;
using farmGate.Server.Data;
using farmGate.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace farmGate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountyController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CountyController(MyDbContext context)
        {
            _context = context;
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
    }
}
