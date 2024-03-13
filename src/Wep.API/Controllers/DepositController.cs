using Application.Deposits.Commands;
using Domain.Entities.Deposits;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Wep.API.Abstractions;

namespace Wep.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : ApiController
    {

        public DepositController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepositCommand request)
        {
            Result<TransactionId> result = await Sender.Send(request);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return Ok(result);
            //return CreatedAtAction(nameof(Get), new { Id = result.Value }, result.Value);
        }

        //[HttpGet("{Id:guid}")]
        //public async Task<IActionResult> Get(Guid Id)
        //{
        //    Result<Deposit> result = await Sender.Send(Id);

        //    if (result.IsFailure)
        //    {
        //        return HandleFailure(result);
        //    }

        //    return CreatedAtAction(nameof(Get), new { Id = result.Value }, result.Value);
        //}


    }
}
