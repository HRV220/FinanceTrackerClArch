using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.Interfaces;

namespace FinanceTrackerAPI.Application.Credits.Queries.GetCreditById;

public class GetCreditByIdQueryHandler
{
  private readonly ICreditRepository _creditRepository;

  public GetCreditByIdQueryHandler(ICreditRepository creditRepository)
  {
    _creditRepository = creditRepository;
  }

  public async Task<Result<GetCreditByIdResponse>> Handle(GetCreditByIdQuery query)
  {
    var credit = await _creditRepository.GetByIdAsync(query.Id);
    if (credit is null)
      return Result<GetCreditByIdResponse>.Failure(new DomainError("Credit.NotFound", "Credit not found."));

    return Result<GetCreditByIdResponse>.Success(new GetCreditByIdResponse(
      credit.Id,
      credit.ProfileId,
      credit.CurrencyId,
      credit.Name,
      credit.TotalAmount,
      credit.RemainingAmount,
      credit.MonthlyPayment,
      credit.InterestRate,
      credit.StartDate,
      credit.EndDate,
      credit.IsClosed));
  }
}
