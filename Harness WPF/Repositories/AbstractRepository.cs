using Harness_WPF.Domain.Entities;
using Harness_WPF.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Harness_WPF.Repositories;

public class Repository : IRepository
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }
}