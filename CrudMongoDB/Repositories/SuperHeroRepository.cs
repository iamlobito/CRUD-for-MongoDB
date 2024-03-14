using CrudMongoDB.Models;
using MongoDB.Driver;

namespace CrudMongoDB.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly IMongoDbConnectionFactory _connectionFactory;
        private readonly IMongoCollection<SuperHero> _collection;

        public SuperHeroRepository(IMongoDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

            var database = _connectionFactory.GetDatabase();
            _collection = database.GetCollection<SuperHero>("superhero");

        }

        public async Task<bool> Create(SuperHero hero)
        {
            try
            {
                await _collection.InsertOneAsync(hero);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var filterDefinition = Builders<SuperHero>.Filter.Eq(a => a.Id, id);
            var result = await _collection.DeleteOneAsync(filterDefinition);
            return result.DeletedCount > 0;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            return await _collection.Find(Builders<SuperHero>.Filter.Empty).ToListAsync();
        }

        public async Task<SuperHero> GetById(string id)
        {
            var filterDefinition = Builders<SuperHero>.Filter.Eq(a => a.Id, id);
            return await _collection.Find(filterDefinition).FirstAsync();
        }

        public async Task<bool> Update(SuperHero hero)
        {
            var filterDefinition = Builders<SuperHero>.Filter.Eq(a=>a.Id, hero.Id);
            var result = await _collection.ReplaceOneAsync(filterDefinition, hero);
            return result.ModifiedCount > 0;
        }
    }
}
