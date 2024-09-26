using Dotnet_v8.Context;
using Dotnet_v8.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_v8.Repository
{
    public class WalksRepository(V8DBContext context): IWalksRepository
    {
        private readonly V8DBContext _context=context;

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks()
        {
            return await _context.Walks.ToListAsync();
        }
        
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _context.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync();
        }
    }
}
