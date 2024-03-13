using Domain.Entities.Denominations;

namespace Domain.Entities.Deposits;

public class DepositLineItem
{
    public DepositLineItemId Id { get; private set; }
    public DenominationId DenominationId { get; private set; }
    public TransactionId TransactionId { get; private set; }
    public int Pieces { get; private set; }

    public DepositLineItem(DepositLineItemId id, DenominationId denominationId, TransactionId transactionId, int pieces)
    {
        Id = id;
        DenominationId = denominationId;
        TransactionId = transactionId;
        Pieces = pieces;
    }

}
