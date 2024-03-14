using MongoDB.Driver;

namespace CrudMongoDB
{
    public class MongoDbConecctionFactory : IMongoDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public MongoDbConecctionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IMongoDatabase GetDatabase()
        {
            var connectionString = _configuration.GetSection("MyDb").GetValue<string>("ConnectionString");
            var databaseName = _configuration.GetSection("MyDb").GetValue<string>("DatabaseName");

            var url = MongoUrl.Create(connectionString);
            var client = new MongoClient(url);
            var database = client.GetDatabase(databaseName);

            return database;
        }
    }
}
