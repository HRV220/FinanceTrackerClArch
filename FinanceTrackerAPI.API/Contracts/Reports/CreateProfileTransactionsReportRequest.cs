namespace FinanceTrackerAPI.API.Contracts.Reports;

public record CreateProfileTransactionsReportRequest(
  Guid ProfileId,
  DateOnly From,
  DateOnly To);