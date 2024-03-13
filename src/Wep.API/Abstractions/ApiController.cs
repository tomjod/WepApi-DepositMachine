using SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wep.API.Abstractions
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        // ISender es una interfaz proporcionada por MediatR para enviar solicitudes.
        protected readonly ISender Sender;

        // Constructor que inyecta una instancia de ISender
        protected ApiController(ISender sender) => Sender = sender;

        // Método para manejar errores en los resultados de las solicitudes a la API.
        // Devuelve un IActionResult basado en el tipo de error en el resultado.
        protected IActionResult HandleFailure(Result result) =>
            result switch
            {
                // Si el resultado es exitoso, lanza una InvalidOperationException.
                { IsSuccess: true } => throw new InvalidOperationException(),
                // Si el resultado es un IValidationResult, devuelve un BadRequest con los detalles del error y los errores de validación.
                IValidationResult validationResult =>
                    BadRequest(
                        CreateProblemDetails(
                            "Validation Error", StatusCodes.Status400BadRequest,
                            result.Error,
                            validationResult.Errors)),
                // En cualquier otro caso, devuelve un BadRequest con los detalles del error.
                _ =>
                    BadRequest(
                        CreateProblemDetails(
                            "Bad Request",
                            StatusCodes.Status400BadRequest,
                            result.Error))
            };

        // Método para crear un objeto ProblemDetails con los detalles del error.
        // ProblemDetails es una clase en ASP.NET Core que proporciona una forma estandarizada de devolver detalles de error en una respuesta de API.
        private static ProblemDetails CreateProblemDetails(
            string title,
            int status,
            Error error,
            Error[]? errors = null) =>
            new()
            {
                Title = title,
                Type = error.Code,
                Detail = error.Message,
                Status = status,
                Extensions = { { nameof(errors), errors } }
            };
    }
}

