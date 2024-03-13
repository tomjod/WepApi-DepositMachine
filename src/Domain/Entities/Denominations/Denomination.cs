using System.ComponentModel.DataAnnotations;
using Domain.Constants;
using Domain.ValueObjects;

namespace Domain.Entities.Denominations;

public class Denomination
{
    public DenominationId Id { get; private set; }

    public Banknote Banknotes { get; private set; }

    // Searches for the denomination ID based on the denomination name provided.
    public DenominationId SearchDenomId(string denomName)
    {
        var denomination = ChileanPesos.AllDenominations.Values.FirstOrDefault(c => c.DenomName == denomName);

        if (denomination == null)
        {
            throw new Exception($"Denominacion '{denomName}' no encontrada.");
        }

        // buscar la clave basado en el valor
        var denomId = ChileanPesos.AllDenominations.First(kv => kv.Value == denomination).Key;

        return denomId;
    }
}
