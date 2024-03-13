// <copyright file="Bolsas.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Bags;
[NotMapped]
public record BagId(Guid Value);
