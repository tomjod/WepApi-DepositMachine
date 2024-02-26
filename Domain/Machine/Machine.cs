// <copyright file="Machine.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace API_Rest_DM.Domain.Models;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Gets or Sets values from Table Maquina.
/// </summary>
public class Machine
{
    public MachineId Id { get; set; }

    public string SerialNumber { get; set; } = string.Empty;

    public int ManufactureYear { get; set; } 

    public DateTime Timestamp { get; set; }

}
