using IndianFilmManager.Data;
using IndianFilmManager.Data.Models;
using IndianFilmManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Services
{
    /// <summary>
    /// Сервис для работы с фильмами.
    /// </summary>
    public class CinemaService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CinemaService"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех фильмов из базы данных.
        /// </summary>
        /// <returns>Список фильмов в виде модели представления.</returns>
        public List<CinemaViewModel> GetAllCinemas()
        {
            return _context.Cinemas
                .Select(c => new CinemaViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Year = c.Year,
                    ActorId1 = c.ActorId1,
                    ActorId2 = c.ActorId2,
                    ActorId3 = c.ActorId3,
                    ActorId4 = c.ActorId4,
                    GenreId1 = c.GenreId1,
                    GenreId2 = c.GenreId2,
                    GenreId3 = c.GenreId3,
                    Score = c.Score
                })
                .ToList();
        }

        /// <summary>
        /// Добавляет новый фильм в базу данных.
        /// </summary>
        /// <param name="cinema">Модель представления нового фильма.</param>
        public void AddCinema(CinemaViewModel cinema)
        {
            var newCinema = new Cinema
            {
                Name = cinema.Name,
                Year = cinema.Year,
                ActorId1 = cinema.ActorId1,
                ActorId2 = cinema.ActorId2,
                ActorId3 = cinema.ActorId3,
                ActorId4 = cinema.ActorId4,
                GenreId1 = cinema.GenreId1,
                GenreId2 = cinema.GenreId2,
                GenreId3 = cinema.GenreId3,
                Score = cinema.Score
            };
            _context.Cinemas.Add(newCinema);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет данные существующего фильма в базе данных.
        /// </summary>
        /// <param name="cinema">Модель представления обновляемого фильма.</param>
        public void UpdateCinema(CinemaViewModel cinema)
        {
            var existingCinema = _context.Cinemas.Find(cinema.Id);
            if (existingCinema != null)
            {
                existingCinema.Name = cinema.Name;
                existingCinema.Year = cinema.Year;
                existingCinema.ActorId1 = cinema.ActorId1;
                existingCinema.ActorId2 = cinema.ActorId2;
                existingCinema.ActorId3 = cinema.ActorId3;
                existingCinema.ActorId4 = cinema.ActorId4;
                existingCinema.GenreId1 = cinema.GenreId1;
                existingCinema.GenreId2 = cinema.GenreId2;
                existingCinema.GenreId3 = cinema.GenreId3;
                existingCinema.Score = cinema.Score;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет фильм из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор фильма для удаления.</param>
        public void DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                _context.SaveChanges();
            }
        }
    }
}