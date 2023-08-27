// Server/Services/CommodityService.cs

using farmGate.Server.Data;
using farmGate.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace farmGate.Server.Services
{
    public class CommodityService
    {
        private readonly MyDbContext _context;

        public CommodityService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Commodity>> GetAllCommoditiesAsync()
        {
            return await _context.Commodities.ToListAsync();
        }

        public async Task<Commodity> AddCommodityAsync(Commodity commodity)
        {
            _context.Commodities.Add(commodity);
            await _context.SaveChangesAsync();
            return commodity;
        }
    }
}