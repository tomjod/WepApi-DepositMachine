// <copyright file="Bolsas.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Entities.Bags;

using System.ComponentModel.DataAnnotations;


public class Bag
{

    public BagId Id { get; private set; }
    public string SerialNumber { get; private set; } = string.Empty;
    public int Capacity { get; private set; }
    public string? CurrentLocation { get; set; } = string.Empty;
    public string? LastLocation {  get; set; } = string.Empty;
    public DateTime? InstallDate { get; set; }
    public DateTime? RemovalDate { get; set; }
    public static Bag Create(string SerialNumber, int capacity)
    {
        var bag = new Bag
        {
            SerialNumber = SerialNumber,
            Capacity = capacity,
            InstallDate = null,
            RemovalDate = null,
            CurrentLocation = null,
            LastLocation = null,
        };

        return bag;
    }

    public void Install(string branchName)
    {
        CurrentLocation = branchName;
        InstallDate = DateTime.UtcNow;
    }

    public void Uninstall()
    {
        RemovalDate = DateTime.UtcNow;
        LastLocation = CurrentLocation;
        CurrentLocation = null;
    }
}
