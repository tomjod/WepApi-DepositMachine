using Application.BanknoteValidationModules.Commands.Create;
using Application.BanknoteValidationModules.Queries.GetBanknoteValidationModuleById;
using Domain.Entities.BanknoteValidationModules;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using SharedKernel;
using Wep.API.Abstractions;
using ISender = MediatR.ISender;

namespace Wep.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BanknoteValidationModuleController : ApiController
{
    public BanknoteValidationModuleController(ISender sender) : base(sender)
    {
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBanknoteValidationModuleCommand request)
    {
        Result<BanknoteValidationModuleId> result = await Sender.Send(request);

        if (result.IsFailure)
        {
            HandleFailure(result);
        }

        return CreatedAtAction(nameof(Get), new { Id = result.Value }, result.Value);

    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var banknoteValidationModuleId = new BanknoteValidationModuleId(id);

        var query = new GetBanknoteValidationModuleByIdQuery(banknoteValidationModuleId);

        Result<BanknoteValidationModule> response = await Sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);

    }

}
