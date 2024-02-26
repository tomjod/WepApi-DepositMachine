// <copyright file="ApplicationUser.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

namespace Domain.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain.Branch;
using Domain.Client;
using Microsoft.AspNetCore.Identity;

/// <summary>
/// Class ApplicationUser that inherit from IdentityUser.
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{

    public string Name { get; private set; } = string.Empty!;

    public string LastName { get; private set; } = string.Empty!;

    public ClientId ClientId { get; private set; }
}

