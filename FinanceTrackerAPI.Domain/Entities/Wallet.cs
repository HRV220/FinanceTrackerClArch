using FinanceTrackerAPI.Domain.Common;
using FinanceTrackerAPI.Domain.ValueObject;

namespace FinanceTrackerAPI.Domain.Entities;

public class Wallet : BaseEntity
{
  public Guid ProfileId {get; private set;}
  public string Name {get; private set;} = string.Empty;
  public string? Icon {get; private set;}
  public int SortOrder {get; private set;}
  public Currency Currency {get; private set;} = null!;
  public decimal InitialBalance {get; private set;} = 0;
public string? Note {get; private set;} = null;
  public bool IsArchived { get; private set;} = false;

  private Wallet() : base()
  {
    
  }
  private Wallet(Guid id, Guid profileId, string name, string? icon, int sortOrder, Currency currency, decimal initialBalance, string? note) : base(id)
  {
    ProfileId = profileId;
    Name = name;
    Icon = icon;
    SortOrder = sortOrder;
    Currency = currency;
    InitialBalance = initialBalance;
    Note = note;
  }

  public static Result<Wallet> Create(Guid profileId, string name, int sortOrder, Currency currency, decimal initialBalance, string? icon = null, string? note = null)
  {
    if (profileId == Guid.Empty)
      return Result<Wallet>.Failure(new DomainError("Wallet.InvalidProfileId", "ProfileId is required."));

    if (string.IsNullOrWhiteSpace(name))
      return Result<Wallet>.Failure(new DomainError("Wallet.InvalidName", "Name is required."));

    if (name.Length > 256)
      return Result<Wallet>.Failure(new DomainError("Wallet.InvalidName", "Name must be 256 characters or less."));

    if (sortOrder < 0)
      return Result<Wallet>.Failure(new DomainError("Wallet.InvalidSortOrder", "SortOrder must be 0 or greater."));

    return Result<Wallet>.Success(new Wallet(Guid.NewGuid(), profileId, name, icon, sortOrder, currency, initialBalance, note));
  }

  public Result<bool> Rename(string newName)
  {
    if (string.IsNullOrWhiteSpace(newName))
      return Result<bool>.Failure(new DomainError("Wallet.InvalidName", "Name is required."));
    if (newName.Length > 256)
      return Result<bool>.Failure(new DomainError("Wallet.InvalidName", "Name must be 256 characters or less."));
    Name = newName;
    SetUpdated();
    return Result<bool>.Success(true);
  }

  public Result<bool> ChangeSortOrder(int newSortOrder)
  {
    if (newSortOrder < 0)
      return Result<bool>.Failure(new DomainError("Wallet.InvalidSortOrder", "SortOrder must be 0 or greater."));
    SortOrder = newSortOrder;
    SetUpdated();
    return Result<bool>.Success(true);
  }

  public void ChangeIcon(string? newIcon)
  {
    Icon = newIcon;
    SetUpdated();
  }

  public void ChangeCurrency(Currency newCurrency)
  {
    Currency = newCurrency;
    SetUpdated();
  }

  public void ChangeNote(string? newNote)
  {
    Note = newNote;
    SetUpdated();
  }
}