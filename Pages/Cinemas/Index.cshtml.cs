using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Pages.Cinemas
{
    /// <summary>
    /// Модель страницы для отображения списка фильмов.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly CinemaService _cinemaService;
        private readonly ActorService _actorService;
        private readonly GenreService _genreService;

        /// <summary>
        /// Список фильмов для отображения на странице.
        /// </summary>
        public List<CinemaViewModel> Cinemas { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="cinemaService">Сервис для работы с фильмами.</param>
        /// <param name="actorService">Сервис для работы с актёрами.</param>
        /// <param name="genreService">Сервис для работы с жанрами.</param>
        public IndexModel(CinemaService cinemaService, ActorService actorService, GenreService genreService)
        {
            _cinemaService = cinemaService;
            _actorService = actorService;
            _genreService = genreService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных фильмов.
        /// </summary>
        public void OnGet()
        {
            var cinemas = _cinemaService.GetAllCinemas();
            var actors = _actorService.GetAllActors();
            var genres = _genreService.GetAllGenres();

            Cinemas = cinemas.Select(c => new CinemaViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Year = c.Year,
                Score = c.Score,
                ActorId1 = c.ActorId1,
                ActorId2 = c.ActorId2,
                ActorId3 = c.ActorId3,
                ActorId4 = c.ActorId4,
                GenreId1 = c.GenreId1,
                GenreId2 = c.GenreId2,
                GenreId3 = c.GenreId3,
                Actor1Name = actors.FirstOrDefault(a => a.Id == c.ActorId1)?.Name,
                Actor2Name = actors.FirstOrDefault(a => a.Id == c.ActorId2)?.Name,
                Actor3Name = actors.FirstOrDefault(a => a.Id == c.ActorId3)?.Name,
                Actor4Name = actors.FirstOrDefault(a => a.Id == c.ActorId4)?.Name,
                Genre1Name = genres.FirstOrDefault(g => g.Id == c.GenreId1)?.Name,
                Genre2Name = genres.FirstOrDefault(g => g.Id == c.GenreId2)?.Name,
                Genre3Name = genres.FirstOrDefault(g => g.Id == c.GenreId3)?.Name
            }).ToList();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для удаления фильма.
        /// </summary>
        /// <param name="id">Идентификатор фильма для удаления.</param>
        /// <returns>Результат перенаправления на страницу списка фильмов.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _cinemaService.DeleteCinema(id);
            return RedirectToPage();
        }
    }
}