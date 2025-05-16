using IndianFilmManager.Data;
using IndianFilmManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// ��������� ������� � ��������� ��������� ������������.
/// </summary>
builder.Services.AddRazorPages();

/// <summary>
/// ������������ �������� ���� ������ � �������������� SQLite.
/// </summary>
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

/// <summary>
/// ������������ ���������������� ������� ��� ������ � �������, ������� � ��������.
/// </summary>
builder.Services.AddScoped<ActorService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<CinemaService>();

var app = builder.Build();

/// <summary>
/// ����������� �������� ��������� HTTP-��������.
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