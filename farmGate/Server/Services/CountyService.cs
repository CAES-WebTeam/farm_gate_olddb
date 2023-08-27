using System.Threading.Tasks;
using farmGate.Server.Data;  
using farmGate.Shared.Models;  
using Microsoft.EntityFrameworkCore;
namespace farmGate.Server.Services
{
    public class CountyService
    {
        private readonly MyDbContext _context;

        public CountyService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<County> GetCountyForLoggedInUser()
        {
            // For demonstration, I'm returning the first County.
            // Replace this with actual logic to get the County for the logged-in user.
            return await _context.Counties.FirstOrDefaultAsync();
        }
    }
}