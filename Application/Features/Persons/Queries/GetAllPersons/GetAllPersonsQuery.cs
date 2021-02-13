﻿using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<PagedResponse<IEnumerable<GetAllPersonsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, PagedResponse<IEnumerable<GetAllPersonsViewModel>>>
    {
        private readonly IPersonRepositoryAsync _repository;
        private readonly IMapper _mapper;
        public GetAllPersonsQueryHandler(IPersonRepositoryAsync repositoryAsync, IMapper mapper)
        {
            _repository = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllPersonsViewModel>>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllPersonsParameter>(request);
            var persons = await _repository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var viewModel = _mapper.Map<IEnumerable<GetAllPersonsViewModel>>(persons);
            return new PagedResponse<IEnumerable<GetAllPersonsViewModel>>(viewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
