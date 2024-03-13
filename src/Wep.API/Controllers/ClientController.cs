using Application.Clients.Commands.Create;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wep.API.Abstractions;
using Wep.API.Contracts.Clients;
using SharedKernel;
using Domain.Entities.Clients;
using Application.Clients.Queries;

namespace Wep.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ApiController
{
    public ClientController(ISender sender)
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(
        [FromBody] RegisterClientRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var command = new CreateClientCommand
            {
                Rut = request.RUT,
                CompanyName = request.CompanyName,
                BusinessType = request.BusinessType,
                Representative = request.Representative,
            };

            Result<ClientId> result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Value.Value }, result.Value.Value);
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var query = new GetClientByIdQuery(Id);

        Result<Client> response = await Sender.Send(query);

        return response.IsSuccess ? Ok(response) : NotFound(response.Error);
    }
}
