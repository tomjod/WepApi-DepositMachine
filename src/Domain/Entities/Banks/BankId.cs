// -----------------------------------------------------------------------
// <copyright file="BankAccount.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Banks;
[NotMapped]
public record BankId(Guid Value);
