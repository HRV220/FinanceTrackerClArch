using FinanceTrackerAPI.Application.Interfaces;
using BCrypt.Net;

namespace FinanceTrackerAPI.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
  public string Hash(string password)
  {
    string hash = BCrypt.Net.BCrypt.HashPassword(password);
    return hash;
  }
}