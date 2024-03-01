using Domain.User;
using Domain.Currency;
using System.Runtime.InteropServices;
using Domain.Client;
using Domain.Branch;

namespace Domain.Deposit;

public class Deposit
{
    private readonly HashSet<DepositLineItem> _depositLineItem = new();

    // Constructor for creating a Deposit object with the specified id, user id, deposit date, and amount of money.
    private Deposit()
    {
    }
    public DepositId Id { get; private set; }
    public UserId UserId { get; private set; }
    public BranchId BranchId { get; private set; }
    public DateTime RecordDate { get; private set; }
    public Cash Cash {get; private set;}

    public IReadOnlyList<DepositLineItem> DepositLineItem => _depositLineItem.ToList();

    // Method to calculate the totals of totalAmount and totalPieces based on the denomination and quantity of each deposit denomination.
    public void CalculateTotals()
    {
    int totalAmount = 0;
    int totalPieces = 0;

        foreach (var depositDenomination in _depositLineItem)
        {
            var denominationId = depositDenomination.DenominationId; 
            if (!ChileanPesos.AllDenominations.TryGetValue(denominationId, out var denomination))
            {
                throw new Exception($"Denominacion '{denominationId}' no encontrada.");
            }

            totalAmount += denomination.Value * depositDenomination.Pieces;
            totalPieces += depositDenomination.Pieces;

        }

        Cash = new Cash(totalPieces, totalAmount);
    }

    // Creates a new Deposit object with the given id, userId, depositDate, and cashAmount and returns it.
    public static Deposit Create(DepositId id, UserId userId, BranchId branchId, DateTime depositDate) 
    {
        if(id == null)
        {
            throw new Exception("El id no puede ser null");
        }

        if(userId == null)
        {
            throw new Exception("El usuario no puede ser null");
        }
        
        if(branchId == null)
        {
            throw new Exception("La sucursal no puede ser null");
        }


        var deposit = new Deposit
        {
            Id = id,
            UserId = userId,
            BranchId = branchId,
            RecordDate = depositDate,
            Cash = new Cash(0, 0)
        };
        
        return deposit;

    }

    // Adds a line item to the deposit with the given denomination ID, deposit ID, and quantity.
    public void AddLineItem(DenominationId denominationId, int pieces)
    {
        if(denominationId == null)
        {
            throw new Exception("La denominacion no puede ser null");
        }

        if(pieces < 0)
        {
            throw new Exception("La cantidad no puede ser negativa");
        }

        var LineItem = new DepositLineItem(
            new DepositLineItemId(Guid.NewGuid()), 
            denominationId, 
            Id, 
            pieces);
        
        _depositLineItem.Add(LineItem);
        
        CalculateTotals();
    }
}
