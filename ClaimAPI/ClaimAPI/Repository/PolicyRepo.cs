using ClaimAPI.Models;
using MongoDB.Driver;

namespace ClaimAPI.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        private IConfiguration _configuration;
        private IMongoCollection<Policy> _policies;

        public PolicyRepo(IConfiguration configuration,IMongoCollection<Policy> mongoPolicy)
        {
            _configuration = configuration;

            var mongoClient = new MongoClient(_configuration["MongoConnection"]);

            var database = mongoClient.GetDatabase("DatabaseName");

            _policies = database.GetCollection<Policy>(
                _configuration["ProductsCollectionName"]);
        }

        public async void AddPolicy(Policy policy)
        {
            await _policies.InsertOneAsync(policy);
        }
    }
}
