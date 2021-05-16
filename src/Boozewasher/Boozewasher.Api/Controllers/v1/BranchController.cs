using Boozewasher.API.Controllers;
using Boozewasher.Application.Features.Branches.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boozewasher.Api.Controllers.v1
{
    public class BranchController : BaseApiController<BranchController>
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var brands = await _mediator.Send(new GetAllBrandsCachedQuery());
        //    return Ok(brands);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var brand = await _mediator.Send(new GetBrandByIdQuery() { Id = id });
        //    return Ok(brand);
        //}

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateBranchCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, UpdateBrandCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await _mediator.Send(command));
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteBrandCommand { Id = id }));
        //}
    }
}
