// <copyright file="CurrencyDenomination.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Denominations;
[NotMapped]
public record DenominationId(int Value);