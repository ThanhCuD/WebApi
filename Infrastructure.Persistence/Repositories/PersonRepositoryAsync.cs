using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonRepositoryAsync : GenericRepositoryAsync<Person>, IPersonRepositoryAsync
    {
        private readonly DbSet<Person> _persons;

        public PersonRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _persons = dbContext.Set<Person>();
        }

        public async Task<IReadOnlyList<Person>> GetPagedReponseAsync(int pageNumber, int pageSize, string name)
        {
            return await _persons
               .Where(_=> !string.IsNullOrEmpty(name)?_.Name.ToUpper().Contains(name.ToUpper()) : true)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
