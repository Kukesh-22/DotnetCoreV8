using Dotnet_v8.Context;
using Dotnet_v8.Models.Domain;
using Dotnet_v8.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_v8.Repository
{
    public class RegionRepository(V8DBContext context):IRegionRepository
    {
        private readonly V8DBContext _context=context;
        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }
        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Region> CreateAsync(Region addRegion)
        {
            await _context.Regions.AddAsync(addRegion);
            await _context.SaveChangesAsync();
            return addRegion;
        }
        public async Task<Region?> UpdateAsync(Guid id,Region region)
        {
            var regionDetail = _context.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDetail == null)
            {
                return null;
            }
            
            regionDetail.Code = region.Code;
            regionDetail.Name = region.Name;
            regionDetail.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var regionDetail = _context.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDetail == null)
            {
                return null;
            }
            _context.Regions.Remove(regionDetail);
            await _context.SaveChangesAsync();
            return regionDetail;
        }
    }
}
