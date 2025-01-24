using PersonDetails.Models;

namespace PersonDetails.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<List<Person>> GetByNameAsync(string name);
    }
}
