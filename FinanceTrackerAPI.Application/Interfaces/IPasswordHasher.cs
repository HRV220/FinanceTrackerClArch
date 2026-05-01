namespace FinanceTrackerAPI.Application.Interfaces;
public interface IPasswordHasher
{
  public string Hash(string password);
}