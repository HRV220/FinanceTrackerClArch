using FinanceTrackerAPI.Domain;

namespace FinanceTrackerAPI.Domain;

public class User : BaseEntity
{
  public Email Email {get; private set;} = null!;

  public PasswordHash PasswordHash {get; private set;} = null!;
    public ICollection<Profile> Profiles { get; private set; } = new List<Profile>();

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