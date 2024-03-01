// -----------------------------------------------------------------------
// <copyright file="SealDeposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Domain.Deposit;
using Domain.Seal;

namespace API_Rest_DM.Domain.Models;
public class SealDeposit
{
    public SealId SealId { get; private set; }

    public DepositId DepositId { get; private set; }

    public int TotalPieces { get; private set; }

    public int TotalAmount { get; private set; }

    public static SealDeposit Create(SealId sealId, DepositId depositId, int totalPieces, int totalAmount)
    {
        if(sealId == null || depositId == null)
        {
            throw new Exception("Los campos no pueden ser null");
        }
        if(totalAmount <= 0 || totalPieces <= 0)
        {
            throw new Exception("La cantidad no puede ser negativa o 0");
        }
        var sealDeposit = new SealDeposit
        {
            SealId = sealId,
            DepositId = depositId,
            TotalPieces = totalPieces,
            TotalAmount = totalAmount
        };
        
        return sealDeposit;
    }
}
