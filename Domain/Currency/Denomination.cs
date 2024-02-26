// <copyright file="CurrencyDenomination.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.Currency;

using System.ComponentModel.DataAnnotations;

public class Denomination
{

    public DenominationId Id { get; private set; }

    public CurrencyId CurrencyId { get; private set; }

    public CurrencyValue CurrencyValue { get; private set; }
}
