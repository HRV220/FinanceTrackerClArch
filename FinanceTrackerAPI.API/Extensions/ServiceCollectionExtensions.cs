using FinanceTrackerAPI.Domain.Interfaces;
using FinanceTrackerAPI.Application.Interfaces;
using FinanceTrackerAPI.Application.Users.Commands.LoginUser;
using FinanceTrackerAPI.Application.Users.Commands.RegisterUser;
using FinanceTrackerAPI.Application.Users.Commands.DeleteUser;
using FinanceTrackerAPI.Application.Users.Commands.ChangeEmail;
using FinanceTrackerAPI.Application.Users.Commands.ChangePassword;
using FinanceTrackerAPI.Application.Users.Queries.GetUserById;
using FinanceTrackerAPI.Application.Wallets.Commands.ChangeCurrency;
using FinanceTrackerAPI.Application.Wallets.Commands.ChangeIcon;
using FinanceTrackerAPI.Application.Wallets.Commands.ChangeNote;
using FinanceTrackerAPI.Application.Wallets.Commands.ChangeSortOrder;
using FinanceTrackerAPI.Application.Wallets.Commands.CreateWallet;
using FinanceTrackerAPI.Application.Wallets.Commands.DeleteWallet;
using FinanceTrackerAPI.Application.Wallets.Commands.RenameWallet;
using FinanceTrackerAPI.Application.Wallets.Queries.GetWalletById;
using FinanceTrackerAPI.Application.Wallets.Queries.GetWalletsByProfileId;
using FinanceTrackerAPI.Application.Profiles.Commands.CreateProfile;
using FinanceTrackerAPI.Application.Profiles.Commands.DeleteProfile;
using FinanceTrackerAPI.Application.Profiles.Commands.RenameProfile;
using FinanceTrackerAPI.Application.Profiles.Commands.ToggleProfileActive;
using FinanceTrackerAPI.Application.Profiles.Queries.GetProfileById;
using FinanceTrackerAPI.Application.Profiles.Queries.GetProfilesByUserId;
using FinanceTrackerAPI.Application.Units.Commands.CreateUnit;
using FinanceTrackerAPI.Application.Units.Commands.DeleteUnit;
using FinanceTrackerAPI.Application.Units.Commands.RenameUnit;
using FinanceTrackerAPI.Application.Units.Queries.GetAllUnits;
using FinanceTrackerAPI.Application.Units.Queries.GetUnitsByProfileId;
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
    services.AddScoped<IProfileRepository, ProfileRepository>();
    services.AddScoped<IWalletRepository, WalletRepository>();
    services.AddScoped<ICurrencyRepository, CurrencyRepository>();
    services.AddScoped<IUnitRepository, UnitRepository>();

    services.AddScoped<IPasswordHasher, PasswordHasher>();
    services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

    return services;
  }
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<RegisterUserCommandHandler>();
    services.AddScoped<LoginUserCommandHandler>();
    services.AddScoped<DeleteUserCommandHandler>();
    services.AddScoped<ChangeEmailCommandHandler>();
    services.AddScoped<ChangePasswordCommandHandler>();
    services.AddScoped<GetUserByIdQueryHandler>();
    services.AddScoped<CreateProfileCommandHandler>();
    services.AddScoped<DeleteProfileCommandHandler>();
    services.AddScoped<RenameProfileCommandHandler>();
    services.AddScoped<ToggleProfileActiveCommandHandler>();
    services.AddScoped<GetProfileByIdQueryHandler>();
    services.AddScoped<GetProfilesByUserIdQueryHandler>();
    services.AddScoped<CreateWalletCommandHandler>();
    services.AddScoped<DeleteWalletCommandHandler>();
    services.AddScoped<RenameWalletCommandHandler>();
    services.AddScoped<ChangeSortOrderCommandHandler>();
    services.AddScoped<ChangeIconCommandHandler>();
    services.AddScoped<ChangeCurrencyCommandHandler>();
    services.AddScoped<ChangeNoteCommandHandler>();
    services.AddScoped<GetWalletByIdQueryHandler>();
    services.AddScoped<GetWalletsByProfileIdQueryHandler>();
    services.AddScoped<CreateUnitCommandHandler>();
    services.AddScoped<DeleteUnitCommandHandler>();
    services.AddScoped<RenameUnitCommandHandler>();
    services.AddScoped<GetAllUnitsQueryHandler>();
    services.AddScoped<GetUnitsByProfileIdQueryHandler>();
    return services;
  }
}