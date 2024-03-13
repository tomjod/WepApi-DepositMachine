using Domain.ValueObjects;

namespace Domain.Entities.Clients;

public class Client
{

    public ClientId Id { get; private set; }

    public RUT Rut { get; private set; } 

    public string CompanyName { get; private set; } = string.Empty!;

    public string BusinessType { get; private set; } = string.Empty;

    public string Representative { get; private set; } = string.Empty;

    public DateTime RecordDate { get; set; }

    public static Client Create(RUT rut, string companyName, string businessType, string representative)
    {
        if (rut == null || companyName == null || businessType == null)
        {
            throw new Exception("Campos no pueden ser null");
        }

        var client = new Client
        {
            Id = new ClientId(Guid.NewGuid()),
            Rut = rut,
            CompanyName = companyName,
            BusinessType = businessType,
            Representative = representative,
            RecordDate = DateTime.UtcNow,
        };

        return client;
    }

}
