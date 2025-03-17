using MyFirstApiProjects.Models.Domain;

namespace MyFirstApiProject.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAlRegionAsync();

        Task<Region?> GetRegionByIdAsync(Guid regionId);

        Task<Region> CreateRegionAsync(Region region);

        Task<Region?> UpdateRegionAsync(Guid id, Region region);

        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
