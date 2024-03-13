using System.Runtime.InteropServices;
using Domain.Entities.Clients;
using Domain.ValueObjects;
using Domain.Entities.Users;
using Domain.Entities.Denominations;
using Domain.Entities.Branches;
using SharedKernel;
using Domain.Constants;

namespace Domain.Entities.Deposits;

public class Deposit
{
    private readonly HashSet<DepositLineItem> _depositLineItem = new();

    // Constructor for creating a Deposit object with the specified id, user id, deposit date, and amount of money.
    private Deposit(
        TransactionId id,
        UserId userId,
        BranchId branchId,
        DateTime recordDate)
    {
        Id = id;
        UserId = userId;
        BranchId = branchId;
        RecordDate = recordDate;
        TotalAmount = 0;
        TotalPieces = 0;
    }
    public TransactionId Id { get; private set; }
    public UserId UserId { get; private set; }
    public BranchId BranchId { get; private set; }
    public DateTime RecordDate { get; private set; }
    public int TotalPieces {  get; private set; }
    public int TotalAmount {  get; private set; }


    public IReadOnlyList<DepositLineItem> DepositLineItem => _depositLineItem.ToList();

    // Method to calculate the totals of totalAmount and totalPieces based on the denomination and quantity of each deposit denomination.
    private void CalculateTotals()
    {
        foreach (var depositDenomination in _depositLineItem)
        {
            var denominationId = depositDenomination.DenominationId;
            if (!ChileanPesos.AllDenominations.TryGetValue(denominationId, out var denomination))
            {
                throw new Exception($"Denominacion '{denominationId}' no encontrada.");
            }

            TotalAmount += denomination.Value * depositDenomination.Pieces;
            TotalPieces += depositDenomination.Pieces;
        }
    }

    // Creates a new Deposit object with the given id, userId, depositDate, and cashAmount and returns it.
    public static Result<Deposit> Create(TransactionId id, UserId userId, BranchId branchId, DateTime depositDate)
    {
        if (id is null)
        {
           return Result.Failure<Deposit>(new Error(
                "Deposit.IdIsNull",
                "Deposit Id can not be null"));
        }

        if (userId is null)
        {
            return Result.Failure<Deposit>(new Error(
                "Deposit.UserIdIsNull",
                "User Id can not be null"));
        }

        if (branchId is null)
        {
            return Result.Failure<Deposit>(new Error(
                 "Deposit.BranchIdIsNull",
                 "Branch Id can not be null"));
        }

        var deposit = new Deposit(
            id,
            userId,
            branchId,
            depositDate);

        return Result.Success(deposit);
    }

    // Adds a line item to the deposit with the given denomination ID, deposit ID, and quantity.
    public Result AddLineItem(DenominationId denominationId, int pieces)
    {
        if (denominationId == null)
        {
            return Result.Failure<Deposit>(new Error(
                             "Deposit.DenominationIdIsNull",
                             "Denomination Id can not be null"));
        }

        if (pieces < 0)
        {
            return Result.Failure<Deposit>(new Error(
                 "DepositLineItem.DenominationPiecesIsNegative",
                 "The pieces quantity can not be negative"));
        }

        var LineItem = new DepositLineItem(
            new DepositLineItemId(Guid.NewGuid()),
            denominationId,
            Id,
            pieces);

        _depositLineItem.Add(LineItem);

        CalculateTotals();

        return Result.Success(LineItem);
    }
}
