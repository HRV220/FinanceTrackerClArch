using FinanceTrackerAPI.Domain.ValueObject;
namespace FinanceTrackerAPI.Domain.Entities;

public class User : BaseEntity
{
  public Email Email {get; private set;} = null!;

  public PasswordHash PasswordHash {get; private set;} = null!;
    public IReadOnlyCollection<Profile> Profiles { get; private set; } = [];

  private User() : base()
  {
    
  }

  private User(Guid id, Email email, PasswordHash passwordHash):base(id)
  {
    Email = email;
    PasswordHash = passwordHash;
  }

  public static User Create(Email email, PasswordHash passwordHash)
  {    
    return new User(Guid.NewGuid(), email, passwordHash);
  }

  public void ChangeEmail(Email newEmail)
  {
    Email = newEmail;
    SetUpdated();
  }

  public void ChangeHashPassword(PasswordHash newHashPassword)
  {
    PasswordHash = newHashPassword;
    SetUpdated();
  }

}