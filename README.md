# FinanceTracker API

REST API для учёта личных финансов. Позволяет вести несколько финансовых профилей, отслеживать транзакции по категориям, управлять кредитами, долгами и вкладами.

## Стек технологий

- **Платформа:** .NET 10, ASP.NET Core
- **База данных:** PostgreSQL
- **ORM:** Entity Framework Core 10
- **Аутентификация:** JWT Bearer
- **Документация API:** OpenAPI (Scalar)

---

## Архитектура

Проект построен по принципам **Clean Architecture** и разделён на 4 слоя:

```
FinanceTrackerCleanArchitecture/
├── FinanceTrackerAPI.Domain/          # Доменный слой
├── FinanceTrackerAPI.Application/     # Слой приложения
├── FinanceTrackerAPI.Infrastructure/  # Инфраструктурный слой
└── FinanceTrackerAPI.API/             # Слой представления (HTTP)
```

### Domain
Ядро системы. Не зависит ни от одного другого слоя.

- **Entities** — бизнес-сущности с приватными сеттерами и фабричными методами (`static Result<T> Create(...)`)
- **Interfaces** — контракты репозиториев (`IWalletRepository`, `ITransactionRepository` и др.)
- **Enums** — `FinancialType` (Income / Expense / Transfer), `RecurrenceInterval`
- **Common** — `Result<T>`, `DomainError`, `BaseEntity`

### Application
Бизнес-логика приложения. Зависит только от Domain.

- Реализует паттерн **CQRS** — команды и запросы разделены в отдельные классы
- Каждая операция: `Command/Query` (входные данные) + `Handler` (логика) + `Response` (выходные данные)
- Никаких внешних фреймворков (без MediatR) — хендлеры регистрируются напрямую в DI

### Infrastructure
Техническая реализация. Зависит от Domain и Application.

- **AppDbContext** — EF Core контекст, конфигурации через `IEntityTypeConfiguration<T>`
- **Repositories** — реализации интерфейсов из Domain
- **Services** — `PasswordHasher`, `JwtTokenGenerator`
- **DataSeeder** — начальное заполнение справочников (валюты, единицы измерения, системные категории)
- Для bulk-обновлений используется `ExecuteUpdateAsync` без загрузки сущностей в трекер

### API
HTTP-слой. Зависит от Application и Infrastructure.

- Контроллеры инжектируют хендлеры напрямую
- Все эндпоинты защищены `[Authorize]`, кроме `/register` и `/login`
- Регистрация всех зависимостей через методы расширения `AddInfrastructure()` / `AddApplication()`

---

## Ключевые концепции

### Railway-Oriented Programming
Вместо исключений используется тип `Result<T>`:

```csharp
public static Result<Credit> Create(...)
{
    if (amount <= 0)
        return Result<Credit>.Failure(new DomainError("Credit.InvalidAmount", "..."));

    return Result<Credit>.Success(new Credit(...));
}
```

Хендлеры проверяют `result.IsFailure` и возвращают `BadRequest` без try/catch.

### Защита инвариантов домена
Конструкторы сущностей приватные. Создание только через фабричные методы. Изменение состояния только через методы сущности (`MakePayment`, `Deactivate`, `Close` и др.).

### Transfers как тип транзакции
Переводы между кошельками не вынесены в отдельную сущность — это транзакция с `Type = Transfer` и заполненным `ToWalletId`. Баланс кошелька считается на лету: `InitialBalance + доходы - расходы - исходящие переводы + входящие переводы`.

### RecurringTransaction как шаблон
Периодические транзакции хранятся отдельно от фактических. `RecurringTransaction` — это план, `Transaction` — факт. При наступлении даты (`NextOccurrenceDate`) сервис создаёт `Transaction` по шаблону и сдвигает дату следующего выполнения.

---

## Доменные сущности

| Сущность | Назначение |
|---|---|
| `User` | Учётная запись |
| `Profile` | Финансовый профиль пользователя (их может быть несколько) |
| `Wallet` | Счёт / кошелёк с балансом |
| `Currency` | Валюта с курсом относительно базовой |
| `Unit` | Единица измерения для транзакций |
| `Category` | Категория транзакции (системная или пользовательская) |
| `Transaction` | Фактическая финансовая операция |
| `RecurringTransaction` | Шаблон периодической транзакции |
| `Credit` | Банковский кредит с графиком погашения |
| `Debt` | Личный долг (я должен кому-то) |
| `Deposit` | Банковский вклад с начислением процентов |

---

## Запуск проекта

**Требования:** .NET 10 SDK, PostgreSQL

**1. Настройте строку подключения** в `FinanceTrackerAPI.API/appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=FinanceTracker;Username=postgres;Password=your_password"
  },
  "Jwt": {
    "Secret": "your_secret_key_min_32_chars"
  }
}
```

**2. Запустите приложение:**
```bash
dotnet run --project FinanceTrackerAPI.API
```

При первом запуске автоматически применяются миграции и заполняются справочники (валюты, единицы измерения, категории).

**3. Документация API** доступна по адресу: `http://localhost:{port}/openapi/v1.json`
