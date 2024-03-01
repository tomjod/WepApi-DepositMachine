// <copyright file="Bolsas.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Bag;

using System.ComponentModel.DataAnnotations;


public class Bag
{

    public BagId Id { get; private set; }

    public string SerialNumber { get; private set; } = string.Empty;

    public DateTime RecordDate { get; private set; }

    public static Bag Create(string SerialNumber)
    {
        var bag = new Bag
        {
            SerialNumber = SerialNumber,
            RecordDate = DateTime.Now,
        };
        return bag;
    }
}
