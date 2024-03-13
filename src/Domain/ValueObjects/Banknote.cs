// <copyright file="CurrencyDenomination.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.ValueObjects;

public record Banknote(string CurrencyCode, string DenomName, int Value);