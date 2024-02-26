using Domain.Address;

namespace API_Rest_DM.Domain.Models;
public class MachineAddress
{
    public int MachineID { get; set; }

    public Machine Machine { get; set; }

    public string AddressID { get; set; }

    public Address Address { get; set; }
}
