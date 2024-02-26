// -----------------------------------------------------------------------
// <copyright file="SealDeposit.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace API_Rest_DM.Domain.Models;
public class SealDeposit
{
    public string SealID { get; set; }

    public string DepositID { get; set; }

    public int TotalPieces { get; set; }

    public decimal TotalAmount { get; set; }
}
