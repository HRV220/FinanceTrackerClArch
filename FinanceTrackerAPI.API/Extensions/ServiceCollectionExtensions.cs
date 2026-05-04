using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Application.Interfaces;
using FinanceTrackerAPI.Application.Users.Commands.LoginUser;
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
    services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

    return services;
  }
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<RegisterUserCommandHandler>();
    services.AddScoped<LoginUserCommandHandler>();
    return services;
  }
}