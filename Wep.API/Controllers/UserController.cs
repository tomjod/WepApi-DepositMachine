using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wep.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Creates a new user using the specified command and returns the result as an IActionResult.
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser command)
    {
        try
        {
             var result = await _mediator.Send(command);

            if(result == null)
            {
                return NotFound();
            }
        
            return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500,ex.Message);
        }
       
    }
}
