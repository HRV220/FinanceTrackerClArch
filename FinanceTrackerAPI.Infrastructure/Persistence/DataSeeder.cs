using FinanceTrackerAPI.Domain.Entities;
using FinanceTrackerAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence;

public static class DataSeeder
{
  public static async Task SeedAsync(AppDbContext context)
  {
    await SeedCurrenciesAsync(context);
    await SeedUnitsAsync(context);
    await SeedCategoriesAsync(context);
  }

  private static async Task SeedCurrenciesAsync(AppDbContext context)
  {
    if (await context.Currencies.AnyAsync())
      return;

    var currencies = new[]
    {
      Currency.Create("Українська гривня",  1,   1.0000m,  "980", "UAH", 1.0000m),
      Currency.Create("Долар США",          1,  41.5000m,  "840", "USD", 41.5000m),
      Currency.Create("Євро",               1,  46.0000m,  "978", "EUR", 46.0000m),
      Currency.Create("Фунт стерлінгів",    1,  54.0000m,  "826", "GBP", 54.0000m),
      Currency.Create("Польський злотий",   1,  10.5000m,  "985", "PLN", 10.5000m),
      Currency.Create("Швейцарський франк", 1,  49.0000m,  "756", "CHF", 49.0000m),
      Currency.Create("Японська єна",       100, 27.5000m, "392", "JPY", 0.2750m),
      Currency.Create("Китайський юань",    1,   5.7000m,  "156", "CNY", 5.7000m),
      Currency.Create("Чеська крона",       10,  1.8500m,  "203", "CZK", 0.1850m),
      Currency.Create("Угорський форинт",   100, 11.0000m, "348", "HUF", 0.1100m),
      Currency.Create("Норвезька крона",    1,   3.9000m,  "578", "NOK", 3.9000m),
      Currency.Create("Шведська крона",     1,   4.1000m,  "752", "SEK", 4.1000m),
    };

    foreach (var result in currencies)
      if (result.IsSuccess)
        context.Currencies.Add(result.Value!);

    await context.SaveChangesAsync();
  }

  private static async Task SeedUnitsAsync(AppDbContext context)
  {
    if (await context.Units.AnyAsync())
      return;

    var units = new[]
    {
      Unit.CreateSystem("Штука",        "шт"),
      Unit.CreateSystem("Кілограм",     "кг"),
      Unit.CreateSystem("Грам",         "г"),
      Unit.CreateSystem("Тонна",        "т"),
      Unit.CreateSystem("Літр",         "л"),
      Unit.CreateSystem("Мілілітр",     "мл"),
      Unit.CreateSystem("Метр",         "м"),
      Unit.CreateSystem("Сантиметр",    "см"),
      Unit.CreateSystem("Кілометр",     "км"),
      Unit.CreateSystem("Квадратний метр", "м²"),
      Unit.CreateSystem("Година",       "год"),
      Unit.CreateSystem("Хвилина",      "хв"),
      Unit.CreateSystem("День",         "дн"),
      Unit.CreateSystem("Місяць",       "міс"),
      Unit.CreateSystem("Рік",          "рік"),
      Unit.CreateSystem("Послуга",      "посл"),
      Unit.CreateSystem("Пакет",        "пак"),
      Unit.CreateSystem("Упаковка",     "уп"),
    };

    foreach (var result in units)
      if (result.IsSuccess)
        context.Units.Add(result.Value!);

    await context.SaveChangesAsync();
  }

  private static async Task SeedCategoriesAsync(AppDbContext context)
  {
    if (await context.Categories.AnyAsync())
      return;

    var incomeCategories = new[]
    {
      Category.CreateSystem("Зарплата",          FinancialType.Income),
      Category.CreateSystem("Фріланс",           FinancialType.Income),
      Category.CreateSystem("Стипендія",         FinancialType.Income),
      Category.CreateSystem("Бонус",             FinancialType.Income),
      Category.CreateSystem("Дивіденди",         FinancialType.Income),
      Category.CreateSystem("Інвестиції",        FinancialType.Income),
      Category.CreateSystem("Оренда (дохід)",    FinancialType.Income),
      Category.CreateSystem("Подарунок",         FinancialType.Income),
      Category.CreateSystem("Повернення боргу",  FinancialType.Income),
      Category.CreateSystem("Кешбек",            FinancialType.Income),
      Category.CreateSystem("Соціальні виплати", FinancialType.Income),
      Category.CreateSystem("Інше",              FinancialType.Income),
    };

    var expenseCategories = new[]
    {
      Category.CreateSystem("Продукти харчування",    FinancialType.Expense),
      Category.CreateSystem("Ресторани та кафе",      FinancialType.Expense),
      Category.CreateSystem("Кава та напої",          FinancialType.Expense),
      Category.CreateSystem("Транспорт",              FinancialType.Expense),
      Category.CreateSystem("Паливо",                 FinancialType.Expense),
      Category.CreateSystem("Таксі",                  FinancialType.Expense),
      Category.CreateSystem("Оренда житла",           FinancialType.Expense),
      Category.CreateSystem("Комунальні послуги",     FinancialType.Expense),
      Category.CreateSystem("Зв'язок та інтернет",   FinancialType.Expense),
      Category.CreateSystem("Одяг та взуття",         FinancialType.Expense),
      Category.CreateSystem("Краса та догляд",        FinancialType.Expense),
      Category.CreateSystem("Охорона здоров'я",      FinancialType.Expense),
      Category.CreateSystem("Ліки та аптека",         FinancialType.Expense),
      Category.CreateSystem("Спорт та фітнес",        FinancialType.Expense),
      Category.CreateSystem("Освіта",                 FinancialType.Expense),
      Category.CreateSystem("Книги та підписки",      FinancialType.Expense),
      Category.CreateSystem("Розваги",                FinancialType.Expense),
      Category.CreateSystem("Техніка та електроніка", FinancialType.Expense),
      Category.CreateSystem("Побутова хімія",         FinancialType.Expense),
      Category.CreateSystem("Подорожі",               FinancialType.Expense),
      Category.CreateSystem("Готель та проживання",   FinancialType.Expense),
      Category.CreateSystem("Страхування",             FinancialType.Expense),
      Category.CreateSystem("Кредити та борги",       FinancialType.Expense),
      Category.CreateSystem("Подарунки (витрати)",    FinancialType.Expense),
      Category.CreateSystem("Благодійність",          FinancialType.Expense),
      Category.CreateSystem("Домашні тварини",        FinancialType.Expense),
      Category.CreateSystem("Діти",                   FinancialType.Expense),
      Category.CreateSystem("Інше",                   FinancialType.Expense),
    };

    var transferCategories = new[]
    {
      Category.CreateSystem("Переказ між рахунками", FinancialType.Transfer),
    };

    foreach (var result in incomeCategories.Concat(expenseCategories).Concat(transferCategories))
      if (result.IsSuccess)
        context.Categories.Add(result.Value!);

    await context.SaveChangesAsync();
  }
}
