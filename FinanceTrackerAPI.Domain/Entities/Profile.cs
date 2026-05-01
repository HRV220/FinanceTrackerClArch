using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Domain;
public class Profile : BaseEntity
{
  public Guid UserId { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public bool IsActive {get; private set;} = true;
  public Currency MainCurrency { get; private set; } = null!;
  public User User { get; private set; } = null!;

  private Profile() : base()
  {
    
  }
  private Profile(Guid id, Guid userId, string name, Currency currency): base (id)
  {
    UserId = userId;
    Name = name;
    MainCurrency = currency;
  }

  public static Profile Create(string name, Currency currency, Guid userId)
  {
    return new Profile(Guid.NewGuid(), userId, name, currency);
  }

  public void Rename(string newName)
  {
    Name = newName;
    SetUpdated();
  }
  public void ActivateDeactivate()
  {
    IsActive = !IsActive;
    SetUpdated();
  }
  public void ChangeCurrency(Currency newCurrency)
  {
    MainCurrency = newCurrency;
    SetUpdated();
  }
}
