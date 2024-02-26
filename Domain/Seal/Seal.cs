// <copyright file="Seal.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Seal;
using Domain.Bag;

public class Seal
{
    public SealId Id { get; private set; }

    public string SealNumber { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTime CreationDate { get; private set; }

    public BagId BagID { get; private set; }

    public int MachineID { get; private set; }
}
