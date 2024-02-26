namespace Domain.BanknoteValidationModule;

using System.ComponentModel.DataAnnotations;

public class BanknoteValidationModule
{
    public BanknoteValidationModuleId Id { get; private set; }

    public string SerialNumber { get; private set; } = string.Empty;

    public string Model { get; private set; } = string.Empty;
   
    public int ManufactureYear { get; private set; }
}
