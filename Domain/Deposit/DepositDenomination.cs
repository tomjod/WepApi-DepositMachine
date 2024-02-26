// <copyright file="DepositoDenominacion.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>


using Domain.Currency;

namespace Domain.Deposit;
public class DepositDenomination
{
    public DepositId DepositId { get; private set; }

    public DenominationId DenominationId { get; private set; }

    public int Quantity { get; private set; }
}
