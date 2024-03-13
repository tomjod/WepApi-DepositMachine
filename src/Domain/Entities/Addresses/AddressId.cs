// <copyright file="Address.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Addresses;
[NotMapped]
public record AddressId(Guid Value);
