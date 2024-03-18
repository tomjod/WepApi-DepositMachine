using Application.Branches.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Wep.API.Abstractions;

namespace Wep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ApiController
    {
        public BranchesController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBranchCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                Result<CreateBranchResponse> result = await Sender.Send(command);

                if (result.IsFailure) 
                { 
                   return HandleFailure(result);
                }

                return Ok(result.Value);
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
