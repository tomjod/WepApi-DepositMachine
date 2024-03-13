using Application.Abstractions.Messaging;

namespace Application.Branches.Commands.Create;

public class CreateBranchCommand : ICommand<CreateBranchResponse>
{
    public string Name { get; set; }
    public string BranchCode { get; set;}
    public Guid ClientId { get; set; }
    public Guid? DepositMachineId { get; set; }
    public int PhoneNumber { get; set; }
    public string Manager { get; set; }
    public string Email { get; set; }
    public AddressCommand Address {get; set;}
}
