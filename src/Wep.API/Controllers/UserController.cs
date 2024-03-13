using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.SetUserRole;
using Application.Users.Queries.GetUserById;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Wep.API.Abstractions;
using Wep.API.Contracts.Users;

namespace Wep.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ApiController
{
    public UserController(ISender sender) 
        : base(sender)
    {
    }

    // Creates a new user using the specified command and returns the result as an IActionResult.
    [HttpPost]
    //[Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Post([FromBody] RegisterUserRequest request)
    {
        try
        {
            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }

            var command = new CreateUserCommand
            {
                FirstName = request.firstname,
                LastName = request.lastname,
                Email = request.email,
                Password = request.password,
                UserName = request.username,
            };

           Result<UserId> result = await Sender.Send(command);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Value }, result.Value);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }


    /// <summary>
    /// Retrieves a user by their ID.
    /// </summary>
    /// <param name="Id">The unique identifier of the user.</param>
    /// <returns>An IActionResult representing the user if found, or an error if not found.</returns>
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        try
        {
            var userId = new UserId(Id);

            var query = new GetUserByIdQuery(userId);

            Result<GetUserByIdResponse> response = await Sender.Send(query);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);

        }

        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("set-role")]
    public async Task<IActionResult> SetUserRole([FromBody] UserRoleRequest request)
    {
        try
        {
            var command = new SetUserRoleCommand
            {
               Id = new UserId(request.Id),
               RoleName = request.roleName,
            };

            Result<UserRoleResponse> response = await Sender.Send(command);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);

        }

        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
