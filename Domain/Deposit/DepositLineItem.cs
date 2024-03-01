using Domain.Currency;

namespace Domain.Deposit;

public class DepositLineItem
{
    public DepositLineItemId Id { get; private set; }
    public DenominationId DenominationId { get; private set; }
    public DepositId DepositId {get; private set;}
    public int Pieces { get; private set; }
    
    public DepositLineItem(DepositLineItemId id, DenominationId denominationId, DepositId depositId, int pieces)
    {
        Id = id;
        DenominationId = denominationId;
        DepositId = depositId;
        Pieces = pieces;
    }

}
