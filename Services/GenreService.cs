using IndianFilmManager.Data;
using IndianFilmManager.Data.Models;
using IndianFilmManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Services
{
    /// <summary>
    /// Сервис для работы с жанрами.
    /// </summary>
    public class GenreService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GenreService"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех жанров из базы данных.
        /// </summary>
        /// <returns>Список жанров в виде модели представления.</returns>
        public List<GenreViewModel> GetAllGenres()
        {
            return _context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();
        }

        /// <summary>
        /// Добавляет новый жанр в базу данных.
        /// </summary>
        /// <param name="genre">Модель представления нового жанра.</param>
        public void AddGenre(GenreViewModel genre)
        {
            var newGenre = new Genre { Name = genre.Name };
            _context.Genres.Add(newGenre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет данные существующего жанра в базе данных.
        /// </summary>
        /// <param name="genre">Модель представления обновляемого жанра.</param>
        public void UpdateGenre(GenreViewModel genre)
        {
            var existingGenre = _context.Genres.Find(genre.Id);
            if (existingGenre != null)
            {
                existingGenre.Name = genre.Name;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет жанр из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор жанра для удаления.</param>
        public void DeleteGenre(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}