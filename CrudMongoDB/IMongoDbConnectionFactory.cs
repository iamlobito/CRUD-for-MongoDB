using MongoDB.Driver;

namespace CrudMongoDB
{
    public interface IMongoDbConnectionFactory
    {
        IMongoDatabase GetDatabase();
    }
}
