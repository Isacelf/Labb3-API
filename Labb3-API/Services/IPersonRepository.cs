using Labb3_API.Models;

namespace Labb3_API.Services
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Interest>> GetPersonByInterest(int id);
        Task<IEnumerable<Link>> GetPersonByLinks(int id);


        Task AddInterestToPerson(int personID, int interest);
        Task AddLinkToPerson(int personID, int interestID, string url);
    }
}