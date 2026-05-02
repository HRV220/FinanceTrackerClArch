using System.Reflection.Metadata;

namespace FinanceTrackerAPI.Application.Interfaces;
public interface IPasswordHasher
{
  public string Hash(string password);
  public bool Verify(string password, string hash);
}