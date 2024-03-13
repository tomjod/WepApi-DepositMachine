// <copyright file="Deposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
namespace Domain.ValueObjects;

public record Cash
{
    public int Pieces { get; init; }
    public int Amount { get; init; }

    public Cash() : this(0, 0)
    {
    }

    private Cash(int pieces, int amount)
    {
        Pieces = pieces;
        Amount = amount;
    }

    public Cash Update(int piecesToAdd, int amountToAdd)
    {
        return new Cash(Pieces + piecesToAdd, Amount + amountToAdd);
    }
}