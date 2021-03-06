﻿using Application.Features.Persons.Queries.GetAllPersons;
using Application.Features.Persons.Queries.GetProductById;
using Application.Features.Products.Commands.CreatePerson;
using Application.Features.Products.Commands.UpdatePerson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace WebApplication.Controller.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class PersonController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllPersonsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, Name = filter.Name }));
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        //POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonByIdCommand { Id = id }));
        }
    }
}
