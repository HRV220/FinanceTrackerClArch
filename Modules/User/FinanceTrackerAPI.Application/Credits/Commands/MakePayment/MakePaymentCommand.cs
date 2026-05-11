namespace FinanceTrackerAPI.Application.Credits.Commands.MakePayment;

public record MakePaymentCommand(Guid CreditId, decimal Amount);
