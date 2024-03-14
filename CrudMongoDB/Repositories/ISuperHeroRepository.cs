using CrudMongoDB.Models;

namespace CrudMongoDB.Repositories
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAll();
        Task<SuperHero> GetById(string id);
        Task<bool> Create(SuperHero hero);
        Task<bool> Update(SuperHero hero);
        Task<bool> Delete(string id);
    }
}
