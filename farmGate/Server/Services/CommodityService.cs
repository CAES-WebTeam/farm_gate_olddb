using farmGate.Server.Data;
using farmGate.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Commodity>> GetCommoditiesByCategoryIdAsync(int categoryId)
        {
            return await _context.Commodities.Where(c => c.CategoryId == categoryId)
                                    .Include(c => c.VolumeUnitID)
                                    .ToListAsync();
        }

        public async Task<Commodity> AddCommodityAsync(Commodity commodity)
        {
            _context.Commodities.Add(commodity);
            await _context.SaveChangesAsync();
            return commodity;
        }

        public async Task<bool> DeleteCommodityAsync(int commodityId)
        {
            var commodity = await _context.Commodities.FindAsync(commodityId);
            if (commodity == null)
            {
                return false;
            }

            _context.Commodities.Remove(commodity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Commodity> UpdateCommodityAsync(Commodity updatedCommodity)
        {
            var existingCommodity = await _context.Commodities.FindAsync(updatedCommodity.CommID);
            if (existingCommodity == null)
            {
                return null;
            }

            existingCommodity.Name   = updatedCommodity.Name;
            existingCommodity.CategoryId = updatedCommodity.CategoryId;
            existingCommodity.Description = updatedCommodity.Description;
            existingCommodity.NoHouses = updatedCommodity.NoHouses;
            existingCommodity.Volume = updatedCommodity.Volume;
            existingCommodity.VolumeUnitID = updatedCommodity.VolumeUnitID;
            existingCommodity.Multiplier = updatedCommodity.Multiplier;
            existingCommodity.NoBatches = updatedCommodity.NoBatches;
            existingCommodity.AvgYield = updatedCommodity.AvgYield;
            existingCommodity.AvgPrice = updatedCommodity.AvgPrice;
            existingCommodity.AvgPriceUnitID = updatedCommodity.AvgPriceUnitID;
            existingCommodity.Active = updatedCommodity.Active;

            await _context.SaveChangesAsync();
            return existingCommodity;
        }
    }
}
