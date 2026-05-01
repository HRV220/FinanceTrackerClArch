
using FinanceTrackerAPI.Domain;
using FinanceTrackerAPI.Application.Interfaces;

namespace FinanceTrackerAPI.Application.Users.Commands.RegisterUser;
public class RegisterUserCommandHandler
{
  private readonly IUserRepository _userRepository;
  private readonly IPasswordHasher _passwordHasher;
  public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
  {
    _userRepository = userRepository;
    _passwordHasher = passwordHasher;

  }

  public async Task<Result<Guid>> Handle(RegisterUserCommand command)
  {
    Result<Email> email = Email.Create(command.Email);
    if(email.IsFailure)
    {
      return Result<Guid>.Failure(email.Error!);
    }
    var existingUser = await _userRepository.GetByEmailAsync(email.Value!);

    if(existingUser != null)
    {
      return Result<Guid>.Failure(new DomainError("User.AlreadyExist", "User with this email has already been created"));
    }
    var hash = _passwordHasher.Hash(command.Password);
    Result<PasswordHash> passHash = PasswordHash.Create(hash);
    if(passHash.IsFailure)
    {
      return Result<Guid>.Failure(passHash.Error!);
    }

    var user = User.Create(email.Value!, passHash.Value!);

    await _userRepository.AddUserAsync(user);
    
    return Result<Guid>.Success(user.Id);

  }
}