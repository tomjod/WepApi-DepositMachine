using Domain.Entities.BanknoteValidationModules;
using SharedKernel;

namespace Domain.Entities.DepositMachines;

public class DepositMachine
{
    public DepositMachineId Id { get; private set; }
    public BanknoteValidationModuleId BanknoteValidationModuleId { get; private set; }
    public string SerialNumber { get; private set; } = string.Empty;
    public string Model { get; private set; }
    public int ManufactureYear { get; private set; }
    public DateTime RecordDate { get; private set; }

    private DepositMachine(
        DepositMachineId id, 
        BanknoteValidationModuleId banknoteValidationModuleId,
        string serialNumber,
        string model,
        int manufactureYear)
    {
        Id = id;
        BanknoteValidationModuleId = banknoteValidationModuleId;
        SerialNumber = serialNumber;
        ManufactureYear = manufactureYear;
        Model = model;
        RecordDate = DateTime.UtcNow;
    }

    public static Result<DepositMachine> Create(
        BanknoteValidationModuleId banknoteValidationModuleId,
        string serialNumber,
        string model,
        int manufactureYear)
    {
        if (banknoteValidationModuleId == null)
        {
            return Result.Failure<DepositMachine>(new Error("banknoteValidationModuleId.IsNull",
                "El Id de BVM is null"));
        }

        if (serialNumber == null)
        {
            return Result.Failure<DepositMachine>(new Error("SerialNumber.IsNull",
                "SerialNumber can't be null"));
        }

       var depositMachine = new DepositMachine(
           new DepositMachineId(Guid.NewGuid()),
           banknoteValidationModuleId, 
           serialNumber,
           model,
           manufactureYear);

        return depositMachine;

    }


}
