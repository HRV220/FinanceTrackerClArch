namespace FinanceTrackerAPI.Application.Wallets.Commands.ChangeNote;

public record ChangeNoteCommand(Guid Id, string? NewNote);
