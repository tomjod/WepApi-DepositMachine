// <copyright file="Deposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
namespace Domain.ValueObjects;

public sealed record Cash
{
    public int Pieces { get; set; }
    public int Amount { get; set; }

    private Cash(int pieces, int amount)
    {
        Pieces = pieces;
        Amount = amount;
    }

    public static Cash Add(int piecesToAdd, int amountToAdd)
    {
        return new Cash(piecesToAdd, amountToAdd);
    }
}