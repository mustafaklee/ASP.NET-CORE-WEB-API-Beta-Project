using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApiProjects.Data;
using MyFirstApiProjects.Models.Domain;
using System.Runtime.CompilerServices;

namespace MyFirstApiProject.Repositories
{
    public class SqlWalkRepositories : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SqlWalkRepositories(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Regions").ToListAsync();
        }
    }
}
