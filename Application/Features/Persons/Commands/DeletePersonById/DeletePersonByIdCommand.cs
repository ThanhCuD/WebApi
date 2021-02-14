using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdatePerson
{
    public partial class DeletePersonByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeletePersonByIdHandler : IRequestHandler<DeletePersonByIdCommand, Response<int>>
        {
            private readonly IPersonRepositoryAsync _personRepositoryAsync;
            public DeletePersonByIdHandler(IPersonRepositoryAsync repository)
            {
                _personRepositoryAsync = repository;
            }

            public async Task<Response<int>> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
            {
                var person = await _personRepositoryAsync.GetByIdAsync(request.Id);
                if(person==null)
                {
                    throw new ApiException($"Not found this id: {request.Id}");
                }
                else
                {
                    await _personRepositoryAsync.DeleteAsync(person);
                    return new Response<int>(person.Id);
                }
            }
        }
    }
    
}
