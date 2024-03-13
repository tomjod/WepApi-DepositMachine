using Domain.Entities.Clients;
using Domain.Entities.Users;
using MediatR;
using System.Windows.Input;
using Application.Abstractions.Messaging;

namespace Application.Clients.Commands.Create;

public class CreateClientCommand : ICommand<ClientId>
{
    public string Rut { get; set; }
    public string CompanyName { get; set; }
    public string BusinessType { get; set; }
    public string Representative { get; set; }
}
