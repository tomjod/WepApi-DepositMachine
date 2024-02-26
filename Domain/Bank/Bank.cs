// -----------------------------------------------------------------------
// <copyright file="BankAccount.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Client;

namespace Domain.Bank;
public class Bank
{
    
    public BankId Id { get; private set; }

    public ClientId ClientId { get; private set; }  

    public int AccountNumber { get; private set; }

    public string BankName { get; private set; } = string.Empty;

    public string AccountType { get; private set; } = string.Empty;
}
