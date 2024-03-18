using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Domain.Entities.DepositMachines;
using Domain.Entities.Clients;
using Domain.Entities.ApiKeys;
using SharedKernel;
using Domain.ValueObjects;

namespace Domain.Entities.Branches;

public class Branch
{
    public BranchId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string BranchCode { get; private set; }

    public ClientId ClientId { get; private set; }

    public DepositMachineId? DepositMachineId { get; private set; }

    public int PhoneNumber { get; private set; }

    public string Manager { get; private set; } = string.Empty;

    public Email Email { get; private set; }

    public string OperationStatus { get; private set; } = string.Empty;

    public DateTime? LastEmptied { get; private set; }

    public static Result<Branch> Create(
        string name,
        ClientId clientId,
        DepositMachineId machineId,
        string branchCode,
        int phoneNumber,
        string manager,
        string email)
    {
        if (clientId is null)
        {
            return Result.Failure<Branch>(new Error(
                "Branch.ClientIdIsNull",
                "Client Id can not be null"));
        }

        var branch = new Branch
        {
            Id = new BranchId(Guid.NewGuid()),
            Name = name,
            ClientId = clientId,
            DepositMachineId = machineId,
            BranchCode = branchCode,
            PhoneNumber = phoneNumber,
            Manager = manager,
            Email = Email.Create(email).Value,
            OperationStatus = "Active",
        };

        return Result.Success(branch); //return branch;
    }
}
