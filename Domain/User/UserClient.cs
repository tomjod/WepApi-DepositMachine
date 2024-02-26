// <copyright file="UsersClients.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>

using Domain.Client;

namespace Domain.User;
public class UserClient
{
 
    public Guid UserId { get; private set; }

    public ClientId ClientId { get; private set; }
}
