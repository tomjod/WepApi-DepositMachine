using Application.Clients.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Wep.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateCLient command)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        catch(Exception ex)
        {
            return StatusCode(500,ex.Message);
        }
        
    }
}
