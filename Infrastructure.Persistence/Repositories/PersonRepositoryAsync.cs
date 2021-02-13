using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PersonRepositoryAsync : GenericRepositoryAsync<Person>, IPersonRepositoryAsync
    {
        private readonly DbSet<Person> _persons;

        public PersonRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _persons = dbContext.Set<Person>();
        }
    }
}
