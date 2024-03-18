using Application.DepositMachines.Commands.Create;
using Application.DepositMachines.Queries.GetDepositMachineById;
using Application.Deposits.Commands;
using Domain.Entities.DepositMachines;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Wep.API.Abstractions;

namespace Wep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositMachinesController : ApiController
    {
        public DepositMachinesController(ISender sender) 
            : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepositMachineCommand command)
        {
            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            Result<DepositMachineId> result = await Sender.Send(command);

            if (result.IsFailure) 
            { 
                return HandleFailure(result);
            }

            var response = new
            {
                Id = result.Value.Value
            };

            return CreatedAtAction(
                nameof(Get),
                response,
                response);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> Get(Guid Id)
        {
           var query = new GetDepositMachineByIdQuery(Id);

            Result<DepositMachine> response = await Sender.Send(query);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
