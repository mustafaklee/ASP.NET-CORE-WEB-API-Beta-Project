using MyFirstApiProjects.Models.Domain;

namespace MyFirstApiProject.Repositories
{
    //bu repo projede farklı bir veritabanına geçildiği seneryoda 2.repo olarak değişim kolaylığını göstermek için oluşturulmuştur.
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region> CreateRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteRegionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAlRegionAsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "AUK",
                    Name = "Auckland",
                    RegionImageUrl = "sample-region.jpeg"
                }
            };
        }

        public Task<Region?> GetRegionByIdAsync(Guid regionId)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
