using FinanceTrackerAPI.Application.Interfaces;
using BCrypt.Net;

namespace FinanceTrackerAPI.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
  public string Hash(string password)
  {
    string hash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    return hash;
  }

  public bool Verify(string password, string hash)
  {
    if(BCrypt.Net.BCrypt.EnhancedVerify(password, hash))
      return true;
    else
      return false;
  }
}