using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;

namespace WebApplication.Controller.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllProductsParameter filter)
        {
            var obj = new GetAllProductsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber };
            var result = await Mediator.Send(obj);
            return Ok(result);
        }
    }
}
