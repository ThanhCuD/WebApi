using Application.Features.Chart.GetChart.Querys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace WebApplication.Controller.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ChartController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetChartQuery()));
        }
    }
}
