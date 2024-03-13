// -----------------------------------------------------------------------
// <copyright file="SealDeposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Domain.Entities.Deposits;

namespace Domain.Entities.Seals;
public class SealDeposit
{
    public SealId SealId { get; private set; }

    public TransactionId TransactionId { get; private set; }

    private SealDeposit(SealId sealId, TransactionId transactionId)
    {
        SealId = sealId;
        TransactionId = transactionId;
    }

    public static SealDeposit Create(SealId sealId, TransactionId transactionId)
    {

        var sealDeposit = new SealDeposit(sealId, transactionId);

        return sealDeposit;
    }
}
