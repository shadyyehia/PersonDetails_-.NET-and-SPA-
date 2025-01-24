using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonDetails.Models;
using PersonDetails.Interfaces;


namespace PersonDetails.Repositories
{
    public class MongoPersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<MongoDbDocument> _personCollection;

        public MongoPersonRepository(IOptions<MongoDbSettings> settings, IMongoClient client)
        {
           var database = client.GetDatabase(settings.Value.DatabaseName);
            _personCollection = database.GetCollection<MongoDbDocument>(settings.Value.CollectionName);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var dbPersons = await _personCollection.Find(_ => true).ToListAsync();

            return  dbPersons.Select(dbPerson => dbPerson.MapMongoPersonToPerson()).ToList() ;
            
        }

        public async Task<List<Person>> GetByNameAsync(string name)
        {
            var dbPersons= await _personCollection.Find(p => p.Name.Contains(name)).ToListAsync();
            return dbPersons.Select(person=> person.MapMongoPersonToPerson()).ToList();
        }
    }
}
