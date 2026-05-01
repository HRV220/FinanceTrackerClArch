using FinanceTrackerAPI.Application.Interfaces;
using FinanceTrackerAPI.Application.Users.Commands.RegisterUser;
using FinanceTrackerAPI.Infrastructure.Persistence;
using FinanceTrackerAPI.Infrastructure.Persistence.Repositories;
using FinanceTrackerAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.API.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IPasswordHasher, PasswordHasher>();
    return services;
  }
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<RegisterUserCommandHandler>();
    return services;
  }
}