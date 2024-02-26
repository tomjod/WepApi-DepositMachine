// -----------------------------------------------------------------------
// <copyright file="Banknotes.cs" company="Mundos Virtuales SPA">
// Copyright (c) Mundos Virtuales SPA. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Domain.Deposit;

public class Banknote
{
    public Banknote()
    {
        Quantity = 0;
    }

    public string Denomination { get; set; }

    public int Quantity { get; set; }
}

public class CurrencyDetails
{
    public CurrencyDetails(string currencyName, List<Denomination> denominations)
    {
        CurrencyName = currencyName;
        Denominations = denominations ?? new List<Denomination>();
    }

    public string CurrencyName { get; }

    public List<Denomination> Denominations { get; }

    public class Denomination
    {
        public Denomination(int denomId, string denomName, int value)
        {
            DenomID = denomId;
            Value = value;
            DenomName = denomName;
        }

        public int DenomID { get; }

        public string DenomName { get; }

        public int Value { get; }
    }
}

public static class CurrencyData
{
    public const string CHILEANPESOS = "CLP";

    public enum ChileanPesosID
    {
        CLP1000 = 16658,
        CLP2000 = 16675,
        CLP5000 = 16676,
        CLP10000 = 16677,
        CLP20000 = 16678,
    }

    public static List<CurrencyDetails> GetCurrencies()
    {
        var currencies = new List<CurrencyDetails>
        {
            new CurrencyDetails(CHILEANPESOS, new List<CurrencyDetails.Denomination>
            {
                new CurrencyDetails.Denomination((int)ChileanPesosID.CLP1000, "CLP_1000", 1000),
                new CurrencyDetails.Denomination((int)ChileanPesosID.CLP2000, "CLP_2000", 2000),
                new CurrencyDetails.Denomination((int)ChileanPesosID.CLP5000, "CLP_5000", 5000),
                new CurrencyDetails.Denomination((int)ChileanPesosID.CLP10000, "CLP_10000", 10000),
                new CurrencyDetails.Denomination((int)ChileanPesosID.CLP20000, "CLP_20000", 20000),
            }),
        };

        return currencies;
    }

}
