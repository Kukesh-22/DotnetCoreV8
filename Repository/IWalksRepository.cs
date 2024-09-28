using Dotnet_v8.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_v8.Repository
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllWalks(string? filterOn = null, string? filterQuery = null, string? sortBy = null,
            bool isAscending=true, int pageNumber=1, int pageSize=1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
    }
}
