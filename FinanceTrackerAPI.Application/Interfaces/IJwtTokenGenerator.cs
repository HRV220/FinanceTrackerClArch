namespace FinanceTrackerAPI.Application.Interfaces;

public interface IJwtTokenGenerator
{
  public string GenerateJwtToken(Guid userId, string email);
}