using Microsoft.AspNetCore.Mvc;
using farmGate.Server.Data;
using farmGate.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace farmGate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_context.Categories.ToList());
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }
    }
}
