using System.Collections.Generic;
using System.Threading.Tasks;
using farmGate.Server.Data; 
using farmGate.Shared.Models;  
using Microsoft.EntityFrameworkCore;

public class CategoryService
{
    private readonly MyDbContext _context;

    public CategoryService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}
