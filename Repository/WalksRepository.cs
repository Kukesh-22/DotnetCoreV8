using Dotnet_v8.Context;
using Dotnet_v8.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_v8.Repository
{
    public class WalksRepository(V8DBContext context) : IWalksRepository
    {
        private readonly V8DBContext _context = context;

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalks(string? filterOn = null, string? filterQuery = null, string? sortBy = null,
            bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = _context.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("lengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }
            int skipRecord = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipRecord).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _context.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync();
        }
    }
}
