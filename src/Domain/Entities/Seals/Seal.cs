// <copyright file="Seal.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Entities.Seals;

using System.Runtime.InteropServices;
using Domain.Entities.Bags;
using Domain.Entities.DepositMachines;
using SharedKernel;

public class Seal
{
    public SealId Id { get; private set; }

    public string SerialNumber { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTime RecordDate { get; private set; }

    public BagId? BagId { get; private set; }

    public DepositMachineId DepositMachineId { get; private set; }

    private Seal(
        string serialNumber,
        BagId? bagId,
        DepositMachineId depositMachineId)
    {
        Id = new SealId(Guid.NewGuid());
        SerialNumber = serialNumber;
        BagId = bagId;
        DepositMachineId = depositMachineId;
        RecordDate = DateTime.UtcNow;
        IsActive = true;

    }

    public static Result<Seal> Create(
        string serialNumber, 
        BagId bagId, 
        DepositMachineId deposiMachineId)
    {
        if (string.IsNullOrWhiteSpace(serialNumber))
        {
            return Result.Failure<Seal>(new Error(
                "Seal.SerialIsNullorEmpty",
                "Serial number is null or empty"));
        }

        var seal = new Seal(
            serialNumber,
            bagId,
            deposiMachineId);

        return seal;
    }

    public void UpdateStatusToFalse()
    {
        IsActive = false;
    }
}
