using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<Person>>
    {
        public int Id { get; set; }
        public class GetProductByIdHandle : IRequestHandler<GetProductByIdQuery, Response<Person>>
        {
            private readonly IPersonRepositoryAsync repositoryAsync;

            public GetProductByIdHandle(IPersonRepositoryAsync repositoryAsync)
            {
                this.repositoryAsync = repositoryAsync;
            }
            public async Task<Response<Person>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var person = await repositoryAsync.GetByIdAsync(request.Id);
                if (person == null) throw new ApiException($"Product Not Found.");
                return new Response<Person>(person);
            }
        }
    }

}
