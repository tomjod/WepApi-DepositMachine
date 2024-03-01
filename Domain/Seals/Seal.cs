// <copyright file="Seal.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Seal;

using System.Runtime.InteropServices;
using Domain.Bag;
using Domain.Machine;

public class Seal
{
    public SealId Id { get; private set; }

    public string SealNumber { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTime CreationDate { get; private set; }

    public BagId BagId { get; private set; }

    public MachineId MachineId { get; private set; }

    public static Seal Create(string sealNumber, BagId bagId, MachineId machineId)
    {
        if(sealNumber == null || bagId == null || machineId == null)
        {
            throw new Exception("Los campos no pueden ser null");
        }
        var seal = new Seal
        {
            Id = new SealId(Guid.NewGuid()),
            SealNumber = sealNumber,
            IsActive = true,
            CreationDate = DateTime.Now,
            BagId = bagId,
            MachineId = machineId
        };

        return seal;
    }
}
