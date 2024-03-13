﻿using Domain.Primitives;
using Infrastructure.Outbox;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        return _dbContext.SaveChangesAsync(cancellationToken);
    }

   
}
