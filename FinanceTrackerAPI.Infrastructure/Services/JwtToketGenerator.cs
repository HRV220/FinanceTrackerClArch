using FinanceTrackerAPI.Application.Interfaces;

namespace FinanceTrackerAPI.Infrastructure.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateJwtToken(Guid userId, string email)
  {
    
  }
}