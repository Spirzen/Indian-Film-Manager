using IndianFilmManager.Data;
using IndianFilmManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Добавляет сервисы в контейнер внедрения зависимостей.
/// </summary>
builder.Services.AddRazorPages();

/// <summary>
/// Регистрирует контекст базы данных с использованием SQLite.
/// </summary>
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// Регистрирует пользовательские сервисы для работы с актёрами, жанрами и фильмами.
/// </summary>
builder.Services.AddScoped<ActorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<CinemaService>();

var app = builder.Build();

/// <summary>
/// Настраивает конвейер обработки HTTP-запросов.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts. 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();