// <copyright file="Address.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Address;

using Domain.Branch;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

public class Address
{
    public AddressId Id { get; private set; }

    public BranchId BranchId { get; private set; }

    public string Address1 { get; private set; } = string.Empty;

    public string Address2 { get; private set; } = string.Empty;

    public string City { get; private set; } = string.Empty;

    public string State { get; private set; } = string.Empty; 

    public string Country { get; private set; } = string.Empty;

    public int PostalCode { get; private set; } 

    public DateTime TimeStamp { get; set; }

    public static Address Create(
        BranchId branchId, 
        string address1, 
        string address2, 
        string city, 
        string state, 
        string country, 
        int postalcode)
    {
        var address = new Address
        {
            Id = new AddressId(Guid.NewGuid()),
            BranchId = branchId,
            Address1 = address1,
            Address2 = address2,
            City = city,
            State = state,
            Country = country,
            PostalCode = postalcode,
        };

        return address;
    }

    public string GetFullAddress() => $"{Address1}, {Address2}, {City}, {Country}";
}
