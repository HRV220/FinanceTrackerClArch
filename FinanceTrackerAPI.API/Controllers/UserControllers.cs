using FinanceTrackerAPI.Application.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
  private readonly RegisterUserCommandHandler _handler;
  public UserController(RegisterUserCommandHandler handler)
  {
    _handler = handler;
  }
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
  {
    var result = await _handler.Handle(command);
    if(result.IsFailure)
      return BadRequest(result.Error);
    
    return Ok(result.Value);
  }
}