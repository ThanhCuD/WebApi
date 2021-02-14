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
    public partial class UpdatePersonCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int LevelInParentage { get; set; }
        public int LevelInFamily { get; set; }
        public bool IsDead { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDead { get; set; }
        public string BurialGround { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public class CreatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Response<int>>
        {
            private readonly IPersonRepositoryAsync _personRepositoryAsync;
            private readonly IMapper _mapper;
            public CreatePersonCommandHandler(IPersonRepositoryAsync repository, IMapper mapper)
            {
                _personRepositoryAsync = repository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
            {
                var person = _personRepositoryAsync.GetByIdAsync(request.Id);
                if(person==null)
                {
                    throw new ApiException($"Not found this id: {request.Id}");
                }
                else
                {
                    var updatePerson = _mapper.Map<Person>(request);
                    await _personRepositoryAsync.UpdateAsync(updatePerson);
                    return new Response<int>(person.Id);
                }
                
            }
        }
    }
    
}
