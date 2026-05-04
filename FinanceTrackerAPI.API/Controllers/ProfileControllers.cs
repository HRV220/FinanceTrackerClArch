using FinanceTrackerAPI.Application.Profiles.Commands.CreateProfile;
using FinanceTrackerAPI.Application.Profiles.Queries.GetProfileById;
using FinanceTrackerAPI.Application.Profiles.Queries.GetProfilesByUserId;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
  private readonly CreateProfileCommandHandler _createProfileHandler;
  private readonly GetProfilesByUserIdQueryHandler _getProfilesByUserIdHandler;
  private readonly GetProfileByIdQueryHandler _getProfileByIdHandler;

  public ProfileController(
    CreateProfileCommandHandler createProfileCommandHandler,
    GetProfilesByUserIdQueryHandler getProfilesByUserIdQueryHandler,
    GetProfileByIdQueryHandler getProfileByIdQueryHandler)
  {
    _createProfileHandler = createProfileCommandHandler;
    _getProfilesByUserIdHandler = getProfilesByUserIdQueryHandler;
    _getProfileByIdHandler = getProfileByIdQueryHandler;
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateProfileCommand command)
  {
    var result = await _createProfileHandler.Handle(command);
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }

  [HttpGet]
  public async Task<IActionResult> GetByUserId([FromQuery] GetProfilesByUserIdQuery query)
  {
    var result = await _getProfilesByUserIdHandler.Handle(query);
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var result = await _getProfileByIdHandler.Handle(new GetProfileByIdQuery(id));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }
}