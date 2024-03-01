using Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Machine;
using System.Net;

namespace Domain.Branch;

public class Branch
{
    public BranchId Id { get; private set; }    

    public string Name { get; private set; } = string.Empty;

    public ClientId ClientId { get; private set; }

    public MachineId MachineId { get; private set; }

    public int PhoneNumber { get; private set; }

    public string Manager {get; private set;} = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string OperationStatus { get; private set; } = string.Empty;

    public int CurrentAmount {get; private set;}

    public int AmountSinceLastEmptied {get; private set;}

    public DateTime? LastEmptied {get; private set;}

    public static Branch Create(
        ClientId clientId, 
        MachineId machineId, 
        int phoneNumber, 
        string manager, 
        string email, 
        string operationStatus)
    {
        if(clientId == null || machineId == null)
        {
            throw new Exception("El cliente o la maquina no pueden ser null");
        }
        
            var branch = new Branch
            {
                Id = new BranchId(Guid.NewGuid()),
                ClientId = clientId,
                MachineId = machineId,
                PhoneNumber = phoneNumber,
                Manager = manager,
                Email = email,
                OperationStatus = operationStatus,
                CurrentAmount = 0,
                AmountSinceLastEmptied = 0,
                LastEmptied = null
            };

        return branch;
    }

    public void UpdateCurrentAmount(int currentAmount)
    {
        if(currentAmount < 0)
        {
            throw new Exception("La cantidad actual no puede ser negativa");
        }

        CurrentAmount += currentAmount;
    }

    public void AddToAmountSinceLastEmptied(int amount)
    {
        if(amount < 0)
        {
            throw new Exception("La cantidad no puede ser negativa");
        }

        AmountSinceLastEmptied += amount;
    }

    public void EmptyMachine()
    {
        CurrentAmount = 0;
        LastEmptied = DateTime.Now;
    }

}
