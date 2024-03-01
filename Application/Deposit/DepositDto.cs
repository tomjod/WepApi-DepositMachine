namespace Application;

public class DepositDto
{
    public int UserId { get; set; }
    public DateTime DepositDate { get; set; }
    public List<DenominationDto> Denominations { get; set; }
}
