using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProductById
{
    public partial class DeleteProductByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public UpdateProductCommandHandler(IProductRepositoryAsync productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
            }

            public async Task<Response<int>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);
                if (product == null)
                {
                    throw new ApiException($"Product Not Found.");
                }
                else
                {
                    await _productRepository.DeleteAsync(product);
                    return new Response<int>(product.Id);
                }
            }
        }
    }
    
}
