using SharedKernel;
using System.Diagnostics;

namespace Domain.Entities.BanknoteValidationModules;

public class BanknoteValidationModule
{
    public BanknoteValidationModuleId Id { get; private set; }

    public string SerialNumber { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;

    public int ManufactureYear { get; private set; }

    private BanknoteValidationModule(
        BanknoteValidationModuleId id, 
        string serialNumber, 
        string model, 
        int manufactureYear)
    {
        Id = id;
        SerialNumber = serialNumber;
        Model = model;
        ManufactureYear = manufactureYear;
    }

    public static Result<BanknoteValidationModule> Create(
        string serialNumber,
        string model,
        int manufactureYear)
    {
        if (string.IsNullOrWhiteSpace(serialNumber)) 
        {
            return Result.Failure<BanknoteValidationModule>(new Error(
                "SerialNumber.IsNull",
                "Serial Number can't be null"));
        }

        if (string.IsNullOrWhiteSpace(model)) 
        {
            return Result.Failure<BanknoteValidationModule>(new Error(
                "Model.IsNull",
                "Model can't be null"));
        }

        var banknoteValidationModule = new BanknoteValidationModule
            (new BanknoteValidationModuleId(Guid.NewGuid()),
            serialNumber,
            model,
            manufactureYear);

        return banknoteValidationModule;
    }
}
