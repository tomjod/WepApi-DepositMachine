// <copyright file="Deposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Deposit;

public class Deposit
{
    
    public DepositId Id { get; private set; }

    public DateTime DepositDate { get; private set; }

    public int TotalPieces { get; private set; }

    public decimal TotalAmount { get; private set; }

    public string UserID { get; private set; }
 
    public virtual List<DepositDenomination> DepositDenomination { get; } = [];

}
