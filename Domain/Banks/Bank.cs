using Domain.Branch;
using Domain.Client;

namespace Domain.Bank;
public class Bank
{
    
    public BankId Id { get; private set; }

    public BranchId BranchId { get; private set; }  

    public int AccountNumber { get; private set; }

    public string BankName { get; private set; } = string.Empty;

    public string AccountType { get; private set; } = string.Empty;

    public int TotalAmount { get; private set; }

    public int WithDrawnAmount { get; private set; }

    public DateTime LastWithdrawn { get; set; }

}
