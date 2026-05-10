using FinanceTrackerAPI.Application.Credits.Commands.CloseCredit;
using FinanceTrackerAPI.Application.Credits.Commands.CreateCredit;
using FinanceTrackerAPI.Application.Credits.Commands.DeleteCredit;
using FinanceTrackerAPI.Application.Credits.Commands.MakePayment;
using FinanceTrackerAPI.Application.Credits.Commands.RenameCredit;
using FinanceTrackerAPI.Application.Credits.Queries.GetCreditById;
using FinanceTrackerAPI.Application.Credits.Queries.GetCreditsByProfileId;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditController : ControllerBase
{
  private readonly CreateCreditCommandHandler _createCreditHandler;
  private readonly DeleteCreditCommandHandler _deleteCreditHandler;
  private readonly RenameCreditCommandHandler _renameCreditHandler;
  private readonly MakePaymentCommandHandler _makePaymentHandler;
  private readonly CloseCreditCommandHandler _closeCreditHandler;
  private readonly GetCreditByIdQueryHandler _getCreditByIdHandler;
  private readonly GetCreditsByProfileIdQueryHandler _getCreditsByProfileIdHandler;

  public CreditController(
    CreateCreditCommandHandler createCreditHandler,
    DeleteCreditCommandHandler deleteCreditHandler,
    RenameCreditCommandHandler renameCreditHandler,
    MakePaymentCommandHandler makePaymentHandler,
    CloseCreditCommandHandler closeCreditHandler,
    GetCreditByIdQueryHandler getCreditByIdHandler,
    GetCreditsByProfileIdQueryHandler getCreditsByProfileIdHandler)
  {
    _createCreditHandler = createCreditHandler;
    _deleteCreditHandler = deleteCreditHandler;
    _renameCreditHandler = renameCreditHandler;
    _makePaymentHandler = makePaymentHandler;
    _closeCreditHandler = closeCreditHandler;
    _getCreditByIdHandler = getCreditByIdHandler;
    _getCreditsByProfileIdHandler = getCreditsByProfileIdHandler;
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateCreditCommand command)
  {
    var result = await _createCreditHandler.Handle(command);
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var result = await _getCreditByIdHandler.Handle(new GetCreditByIdQuery(id));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }

  [HttpGet]
  public async Task<IActionResult> GetByProfileId([FromQuery] Guid profileId)
  {
    var result = await _getCreditsByProfileIdHandler.Handle(new GetCreditsByProfileIdQuery(profileId));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return Ok(result.Value);
  }

  [HttpPut("{id}/rename")]
  public async Task<IActionResult> Rename(Guid id, [FromBody] string newName)
  {
    var result = await _renameCreditHandler.Handle(new RenameCreditCommand(id, newName));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return NoContent();
  }

  [HttpPost("{id}/payment")]
  public async Task<IActionResult> MakePayment(Guid id, [FromBody] decimal amount)
  {
    var result = await _makePaymentHandler.Handle(new MakePaymentCommand(id, amount));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return NoContent();
  }

  [HttpPatch("{id}/close")]
  public async Task<IActionResult> Close(Guid id)
  {
    var result = await _closeCreditHandler.Handle(new CloseCreditCommand(id));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    var result = await _deleteCreditHandler.Handle(new DeleteCreditCommand(id));
    if (result.IsFailure)
      return BadRequest(result.Error);
    return NoContent();
  }
}
