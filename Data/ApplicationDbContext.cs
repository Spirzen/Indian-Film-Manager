using Microsoft.EntityFrameworkCore;
using IndianFilmManager.Data.Models;

namespace IndianFilmManager.Data
{
    /// <summary>
    /// Контекст базы данных для управления данными приложения.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Набор данных актёров.
        /// </summary>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// Набор данных жанров.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Набор данных фильмов.
        /// </summary>
        public DbSet<Cinema> Cinemas { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Параметры конфигурации контекста базы данных.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}