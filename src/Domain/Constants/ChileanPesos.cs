using System.Net;
using Domain.Entities.Denominations;
using Domain.ValueObjects;

namespace Domain.Constants;

public static class ChileanPesos
{
    // Denominations
    public static readonly Banknote CLP1000 = new("CLP", "CLP_1000", 1000);
    public static readonly Banknote CLP2000 = new("CLP", "CLP_2000", 2000);
    public static readonly Banknote CLP5000 = new("CLP", "CLP_5000", 5000);
    public static readonly Banknote CLP10000 = new("CLP", "CLP_10000", 10000);
    public static readonly Banknote CLP20000 = new("CLP", "CLP_20000", 20000);

    // Denominations ID for CLP
    public static readonly DenominationId CLP1000Id = new(16658);
    public static readonly DenominationId CLP2000Id = new(16675);
    public static readonly DenominationId CLP5000Id = new(16676);
    public static readonly DenominationId CLP10000Id = new(16677);
    public static readonly DenominationId CLP20000Id = new(16678);


    // Denominations Matching properties
    public static readonly Dictionary<DenominationId, Banknote> AllDenominations = new()
    {
        { CLP1000Id, CLP1000 },
        { CLP2000Id, CLP2000 },
        { CLP5000Id, CLP5000 },
        { CLP10000Id, CLP10000 },
        { CLP20000Id, CLP20000 }
    };

    public static readonly IEnumerable<Banknote> CLPDenominations = new List<Banknote>
    {
        CLP1000, 
        CLP2000, 
        CLP5000, 
        CLP10000, 
        CLP20000
    };
}