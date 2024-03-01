using Domain.BanknoteValidationModule;

namespace Domain.Machine;

public class Machine
{
    public MachineId Id { get; private set; }
    public BanknoteValidationModuleId BanknoteValidationModuleId { get; private set; }  
    public string SerialNumber { get; private set; } = string.Empty;
    public int ManufactureYear { get; private set; } 
    public DateTime Timestamp { get; private set; }

}
