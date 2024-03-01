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

    public DateTime TimeStamp { get; set; }

    public static Client Create(string vatNumber, string companyName, string businessType, string representative)
    {
        if(vatNumber == null || companyName == null || businessType == null)
        {
            throw new Exception("Campos no pueden ser null");
        }

        var client = new Client
        {
            Id = new ClientId(Guid.NewGuid()),
            VATnumber = vatNumber,
            CompanyName = companyName,
            BusinessType = businessType,
            Representative = representative,
        };

        return client;
    }

}
