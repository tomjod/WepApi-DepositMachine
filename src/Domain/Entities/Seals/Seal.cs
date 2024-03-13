// <copyright file="Seal.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Entities.Seals;

using System.Runtime.InteropServices;
using Domain.Entities.Bags;
using Domain.Entities.DepositMachines;

public class Seal
{
    public SealId Id { get; private set; }

    public string SealNumber { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTime RecordDate { get; private set; }

    public BagId BagId { get; private set; }

    public DepositMachineId DepositMachineId { get; private set; }

    public static Seal Create(string sealNumber, BagId bagId, DepositMachineId deposiMachineId)
    {
        if (sealNumber == null || bagId == null || deposiMachineId == null)
        {
            throw new Exception("Los campos no pueden ser null");
        }
        var seal = new Seal
        {
            Id = new SealId(Guid.NewGuid()),
            SealNumber = sealNumber,
            IsActive = true,
            RecordDate = DateTime.Now,
            BagId = bagId,
            DepositMachineId = deposiMachineId
        };

        return seal;
    }
}
