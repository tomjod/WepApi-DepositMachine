// <copyright file="Cliente.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Client;
[NotMapped]
public record ClientId(Guid Value);