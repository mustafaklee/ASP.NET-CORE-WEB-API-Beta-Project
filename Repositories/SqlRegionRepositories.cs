using MyFirstApiProjects.Models.Domain;
using MyFirstApiProjects.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MyFirstApiProject.Repositories
{
    public class SqlRegionRepositories : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SqlRegionRepositories(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            //asenkron olmayan satır dbContext.Regions.Add(regionDomain);
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingRegion == null) {
                return null;
            }
            //remove de asenktronluk aranmaz.
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAlRegionAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        //Bu metod'da null dönebilir.Bu yüzden Task<Region?> şeklinde tanımladık.
        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            //if doesnt exist?
            //asenkron olmayan satır var regionDomainModel = dbContext.Regions.FirstOrDefault(m => m.Id == id);
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null) { 
                return null;
            }
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
