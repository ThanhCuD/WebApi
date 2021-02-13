using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public partial class CreatePersonCommand : IRequest<Response<int>>
    {
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
        public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Response<int>>
        {
            private readonly IPersonRepositoryAsync _personRepositoryAsync;
            private readonly IMapper _mapper;
            public CreatePersonCommandHandler(IPersonRepositoryAsync repository, IMapper mapper)
            {
                _personRepositoryAsync = repository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
            {
                var person = _mapper.Map<Person>(request);
                await _personRepositoryAsync.AddAsync(person);
                return new Response<int>(person.Id);
            }
        }
    }
    
}
