using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Options;
using PersonDetails.Interfaces;
using PersonDetails.Models;
using System.Globalization;
using System.IO;
namespace PersonDetails.Repositories
{
    public class CsvPersonRepository : IPersonRepository
    {
        private readonly string _filePath;

        public CsvPersonRepository(IOptions<CsvSettings> csvSettings)
        {
            _filePath = csvSettings.Value.FilePath;
        }

        public Task<List<Person>> GetAllAsync()
        {

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<CSV_map>();
            var records= csv.GetRecords<Person>().ToList();
            return Task.FromResult(records);


        }

        public Task<List<Person>> GetByNameAsync(string name)
        {
            var persons = GetAllAsync().Result.Where(p => p.first_name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Task.FromResult(persons);
        }
    }
}
