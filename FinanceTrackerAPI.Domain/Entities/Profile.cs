namespace FinanceTrackerAPI.Domain.Entities;
public class Profile :BaseEntity
{
  public Guid UserId { get; set; }
  public string Name { get; set; } = string.Empty;
  public string MainCurrency { get; set; } = "RUB";
  public User User { get; set; } = null!;
}
