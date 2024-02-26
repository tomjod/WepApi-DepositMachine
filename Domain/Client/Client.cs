// <copyright file="Cliente.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Client;

using System.ComponentModel.DataAnnotations;

public class Client
{

    public ClientId Id { get; private set; }

    public string VATnumber { get; private set; } = string.Empty;

    public string CompanyName { get; private set; } = string.Empty!;

    public string BusinessType { get; private set; } = string.Empty;

    public string Representative { get; private set; } = string.Empty;

    public int  PhoneNumber { get; private set; } 


    public DateTime TimeStamp { get; set; }

}
