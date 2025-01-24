using PersonDetails.Interfaces;
using PersonDetails.Models;

namespace PersonDetails.Services
{
    public interface IPersonService
    {
        public Task<List<Person>> GetPersons(string? filter);

    }

    public class PersonService : IPersonService
    {
        IPersonRepository CsvRepo { get; }
        IPersonRepository MongoRepo { get; }

        public PersonService(IPersonRepository csvRepo, IPersonRepository mongoRepo)
        {
            CsvRepo = csvRepo;
            MongoRepo = mongoRepo;
        }
        public async Task<List<Person>> GetPersons(string? filter)
        {

            if (filter != null)
            {
                var personsFromCSV = await CsvRepo.GetByNameAsync(filter);
                var personsFromMongo = await MongoRepo.GetByNameAsync(filter);
                var persons = personsFromCSV.Concat(personsFromMongo).ToList();
                return persons;
            }
            else
            {
                var personsFromCSV = await CsvRepo.GetAllAsync();
                var personsFromMongo = await MongoRepo.GetAllAsync();
                var persons = personsFromCSV.Concat(personsFromMongo).ToList();
                return persons;
            }

        }
    }
}
