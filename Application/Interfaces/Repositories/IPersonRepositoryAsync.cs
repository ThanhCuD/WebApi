using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPersonRepositoryAsync : IGenericRepositoryAsync<Person>
    {
        Task<IReadOnlyList<Person>> GetPagedReponseAsync(int pageNumber, int pageSize, string Name);
        Task<int> TotalCount();
    }
}
