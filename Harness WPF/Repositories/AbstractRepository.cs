using Harness_WPF.Domain.Entities;
using Harness_WPF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Repositories;

public class Repository
{
    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<HarnessDrawing>> GetAllAsync()
    {
        return await _context.Set<HarnessDrawing>().ToListAsync();
    }
}

