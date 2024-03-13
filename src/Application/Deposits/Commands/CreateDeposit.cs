using Application.Abstractions.Messaging;
using Domain.Entities.Deposits;
using Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Deposits.Commands;

public sealed record CreateDepositCommand : ICommand<TransactionId>
{
    public string TransactionId { get; set; }

    public Guid UserId { get; set; }

    public Guid BranchId { get; set; }

    public Guid SealId { get; set; }

    public DateTime DepositDate { get; set; }
    public IList<DenominationPieces> DenominationPieces { get; set; } = new List<DenominationPieces>();

}

public sealed record DenominationPieces
{
    public int DenominationId { get; set; } = default!;
    public int Pieces { get; set; } 
}
