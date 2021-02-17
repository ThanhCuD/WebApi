using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Chart.GetChart.Querys
{
    public class GetChartQuery : IRequest<Response<GetChartViewModel>>
    {
    }
    public class GetChartQueryHandler : IRequestHandler<GetChartQuery, Response<GetChartViewModel>>
    {
        private readonly IPersonRepositoryAsync _repository;
        public GetChartQueryHandler(IPersonRepositoryAsync repositoryAsync)
        {
            _repository = repositoryAsync;
        }
        public async Task<Response<GetChartViewModel>> Handle(GetChartQuery request, CancellationToken cancellationToken)
        {
            GetChartViewModel result = new GetChartViewModel();
            var allPerson = await _repository.GetAllAsync();
            var root = allPerson.FirstOrDefault(_ => _.IdParent == 0);
            if (root != null)
            {
                result.Id = root.Id;
                result.Name = root.Name;
                result.Description = "";
                result.Children = findChild(root);
            }
            return new Response<GetChartViewModel>(result);
        }
        
        private List<GetChartViewModel> findChild(Person root)
        {
            var lst = new List<GetChartViewModel>();
            var children = _repository.GetAllAsync().Result.Where(_ => _.IdParent == root.Id).ToList();
            foreach (var item in children)
            {
                var child = new GetChartViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Children  = findChild(item)
                };
                lst.Add(child);
            }
            return lst;
        }
    }
}
