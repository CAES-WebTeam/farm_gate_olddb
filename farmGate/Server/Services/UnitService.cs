using farmGate.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace farmGate.Server.Services
{
    public class UnitService
    {
        private readonly MyDbContext _context;

        public UnitService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unit>> GetAllUnitsAsync()
        {
            return await _context.Units.ToListAsync();
        }

        public async Task<Unit> GetUnitByIdAsync(int unitId)
        {
            return await _context.Units.FindAsync(unitId);
        }

        public async Task<Unit> AddUnitAsync(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task<Unit> UpdateUnitAsync(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task DeleteUnitAsync(int unitId)
        {
            var unit = await _context.Units.FindAsync(unitId);
            if (unit != null)
            {
                _context.Units.Remove(unit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
