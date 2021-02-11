using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetProductByIdQuery : IRequest<Response<Product>>
    {
        public int Id { get; set; }
    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<Product>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null) throw new ApiException($"Product Not Found.");
            return new Response<Product>(product);
        }
    }
}
