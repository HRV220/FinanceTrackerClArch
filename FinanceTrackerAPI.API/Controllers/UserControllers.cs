using FinanceTrackerAPI.Application.Users.Commands.LoginUser;
using FinanceTrackerAPI.Application.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
  private readonly RegisterUserCommandHandler _registerHandler;
  private readonly LoginUserCommandHandler _loginHandler;
  public UserController(RegisterUserCommandHandler registerHandler, LoginUserCommandHandler loginHandler)
  {
    _loginHandler = loginHandler;
    _registerHandler = registerHandler;
  }
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
  {
    var result = await _registerHandler.Handle(command);
    if(result.IsFailure)
      return BadRequest(result.Error);
    
    return Ok(result.Value);
  }
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
  {
    var result = await _loginHandler.Handle(command);

    if(result.IsFailure)
      return BadRequest(result.Error);
    
    return Ok(result.Value);
  }
}