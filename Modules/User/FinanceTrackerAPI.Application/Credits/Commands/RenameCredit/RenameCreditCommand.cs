namespace FinanceTrackerAPI.Application.Credits.Commands.RenameCredit;

public record RenameCreditCommand(Guid Id, string NewName);
