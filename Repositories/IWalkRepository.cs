using Microsoft.AspNetCore.Mvc;
using MyFirstApiProject.Models.DTO;
using MyFirstApiProjects.Models.Domain;

namespace MyFirstApiProject.Repositories
{
    public interface IWalkRepository
    {
        public Task<Walk> CreateWalkAsync(Walk walk);
        public Task<List<Walk>> GetAllWalksAsync();
    }
}
