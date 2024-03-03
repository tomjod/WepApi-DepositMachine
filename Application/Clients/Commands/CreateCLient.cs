using Domain.Client;
using MediatR;

namespace Application.Clients.Commands;

public class CreateCLient : IRequest<Client>
{
    public string VATnumber { get; set; }
    public string CompanyName { get; set; }
    public string BusinessType { get; set; }
    public string Representative { get; set; }
}
