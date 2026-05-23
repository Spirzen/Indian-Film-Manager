# Indian Film Manager

Веб-приложение для учёта и просмотра каталога индийского (болливудского) кино: фильмы, актёры, жанры и рейтинги. Интерфейс на русском языке, оформление в тёмной «кинотеатральной» теме с золотыми акцентами.

## Возможности

| Раздел | Что умеет |
|--------|-----------|
| **Главная** | Счётчики (фильмы, актёры, жанры), средний рейтинг, топ-5 по оценке, быстрые ссылки |
| **Фильмы** | Карточки с годом, актёрами, жанрами и рейтингом (1–10 ★); поиск по названию; добавление / редактирование / удаление |
| **Актёры** | Список звёзд, CRUD |
| **Жанры** | Сетка жанров, CRUD |

Дополнительно:

- подтверждение перед удалением записи;
- автоматическое применение миграций EF Core при старте;
- демо-наполнение базы классикой Болливуда (если каталог фильмов пуст).

## Скриншоты

> Добавьте сюда 1–2 скриншота главной и каталога фильмов после запуска — для портфолио это сильно помогает.

## Стек технологий

- [.NET 8](https://dotnet.microsoft.com/) — ASP.NET Core Razor Pages
- [Entity Framework Core 9](https://learn.microsoft.com/ef/core/) + SQLite
- [Bootstrap 5](https://getbootstrap.com/) + [Bootstrap Icons](https://icons.getbootstrap.com/)
- Кастомные стили: `wwwroot/css/site.css`

## Требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) или новее

Проверка установки:

```bash
dotnet --version
```

## Быстрый старт

```bash
git clone <url-репозитория>
cd "Indian Film Manager"
dotnet restore
dotnet run
```

Откройте в браузере адрес из вывода консоли:

| Профиль | URL по умолчанию |
|---------|------------------|
| HTTP | http://localhost:5121 |
| HTTPS | https://localhost:7071 |

Запуск с явным профилем:

```bash
dotnet run --launch-profile https
```

Другой порт (если `5121` занят):

```bash
dotnet run --urls "http://localhost:5500"
```

## Демо-данные

При первом запуске, если в таблице фильмов нет записей, создаются:

- **8 актёров** — Шахрух Хан, Амитабх Баччан, Аамир Хан и др.;
- **6 жанров** — драма, мелодрама, экшен, комедия и т.д.;
- **7 фильмов** — «Три идиота», «Шолай», «Дилвале дулхания ле джаяенге» и др.

Чтобы **пересоздать** демо-набор:

1. Остановите приложение (`Ctrl+C`).
2. Удалите файл `IndianFilmManager.db` в корне проекта.
3. Запустите `dotnet run` снова.

> Сидер не перезаписывает уже существующие данные — только заполняет пустую базу.

## База данных

- Файл SQLite: `IndianFilmManager.db` (создаётся автоматически).
- Строка подключения: `appsettings.json` → `ConnectionStrings:DefaultConnection`.

Миграции применяются при каждом старте приложения (`Program.cs`). Создание новой миграции вручную:

```bash
dotnet ef migrations add <ИмяМиграции>
```

> Для `dotnet ef` нужен глобальный инструмент:  
> `dotnet tool install --global dotnet-ef`

## Структура проекта

```
Indian Film Manager/
├── Data/
│   ├── ApplicationDbContext.cs   # EF Core контекст
│   ├── DbInitializer.cs          # Демо-данные
│   └── Models/                   # Actor, Genre, Cinema
├── Services/
│   ├── ActorService.cs
│   ├── GenreService.cs
│   ├── CinemaService.cs
│   └── DashboardService.cs
├── Models/                       # ViewModel для страниц
├── Pages/                        # Razor Pages (UI)
│   ├── Index.cshtml              # Дашборд
│   ├── Cinemas/
│   ├── Actors/
│   └── Genres/
├── Migrations/                   # EF Core миграции
├── wwwroot/
│   ├── css/site.css              # Тема оформления
│   └── js/site.js                # Подтверждение удаления
└── Program.cs
```

## Устранение неполадок

### Порт уже занят (`address already in use`)

Другой экземпляр приложения всё ещё слушает `5121`. В PowerShell:

```powershell
Get-NetTCPConnection -LocalPort 5121 | Select-Object OwningProcess
Stop-Process -Id <PID> -Force
```

Либо запустите на другом порту: `dotnet run --urls "http://localhost:5500"`.

### Демо-фильмы не появились

База уже была создана без фильмов, но с актёрами/жанрами — удалите `IndianFilmManager.db` и перезапустите приложение.

### Логи миграций в консоли

Сообщение `No migrations were applied. The database is already up to date` — **норма**, не ошибка.

## Лицензия

Проект распространяется под лицензией MIT — см. файл [LICENSE.txt](LICENSE.txt).
