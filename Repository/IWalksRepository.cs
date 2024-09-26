using Dotnet_v8.Models.Domain;

namespace Dotnet_v8.Repository
{
    public interface IWalksRepository
    {
        Task<List<Walk>> GetAllWalks();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
    }
}
