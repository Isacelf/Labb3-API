using Labb3_API.Data;
using Labb3_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services
{
    public class PersonRepository : IPersonRepository
    {
        private AppDbContext _dbContext;
        public PersonRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _dbContext.Persons.ToListAsync();
        }


        public async Task<IEnumerable<Interest>> GetPersonByInterest(int id)
        {
            var personInterest = await _dbContext.PersonInterests.Where(p => p.PersonID == id).Select(p => p.Interest).ToListAsync();

            return personInterest;
        }


        public async Task<IEnumerable<Link>> GetPersonByLinks(int id)
        {
            return await _dbContext.PersonInterests.Where(p => p.PersonID == id).SelectMany(u => u.Links).ToListAsync();
        }

        public async Task AddInterestToPerson(int personID, int interest)
        {
            var personInterestLink = new PersonInterest
            {
                PersonID = personID,
                InterestID = interest
            };
            _dbContext.PersonInterests.Add(personInterestLink);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddLinkToPerson(int personID, int interestID, string url)
        {
            var result = new PersonInterest
            {
                PersonID = personID,
                InterestID = interestID,
                Links = new List<Link>() { new Link { Url = url } }
            };

            _dbContext.PersonInterests.Add(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}