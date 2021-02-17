using System.Collections.Generic;

namespace Application.Features.Chart.GetChart.Querys
{
    public class GetChartViewModel 
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public List<GetChartViewModel> Children { get; set; }
        public GetChartViewModel()
        {
            Children = new List<GetChartViewModel>();
        }
    }
}
