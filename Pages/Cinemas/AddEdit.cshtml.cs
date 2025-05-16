using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Cinemas
{
    /// <summary>
    /// Модель страницы для добавления или редактирования фильма.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly CinemaService _cinemaService;
        private readonly ActorService _actorService;
        private readonly GenreService _genreService;

        /// <summary>
        /// Модель данных фильма для формы.
        /// </summary>
        [BindProperty]
        public CinemaViewModel Cinema { get; set; }

        /// <summary>
        /// Список актёров для выпадающего списка.
        /// </summary>
        public List<ActorViewModel> Actors { get; set; }

        /// <summary>
        /// Список жанров для выпадающего списка.
        /// </summary>
        public List<GenreViewModel> Genres { get; set; }

        /// <summary>
        /// Имя первого актёра.
        /// </summary>
        public string ActorName1 { get; set; }

        /// <summary>
        /// Имя второго актёра.
        /// </summary>
        public string ActorName2 { get; set; }

        /// <summary>
        /// Имя третьего актёра.
        /// </summary>
        public string ActorName3 { get; set; }

        /// <summary>
        /// Имя четвёртого актёра.
        /// </summary>
        public string ActorName4 { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли операция редактированием.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="cinemaService">Сервис для работы с фильмами.</param>
        /// <param name="actorService">Сервис для работы с актёрами.</param>
        /// <param name="genreService">Сервис для работы с жанрами.</param>
        public AddEditModel(CinemaService cinemaService, ActorService actorService, GenreService genreService)
        {
            _cinemaService = cinemaService;
            _actorService = actorService;
            _genreService = genreService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных фильма.
        /// </summary>
        /// <param name="id">Идентификатор фильма для редактирования (опционально).</param>
        /// <returns>Результат отображения страницы.</returns>
        public IActionResult OnGet(int? id)
        {
            Actors = _actorService.GetAllActors();
            Genres = _genreService.GetAllGenres();

            if (id.HasValue)
            {
                var cinema = _cinemaService.GetAllCinemas().FirstOrDefault(c => c.Id == id.Value);
                if (cinema == null)
                {
                    return NotFound();
                }

                Cinema = cinema;
                IsEdit = true;

                ActorName1 = _actorService.GetAllActors().FirstOrDefault(a => a.Id == cinema.ActorId1)?.Name;
                ActorName2 = _actorService.GetAllActors().FirstOrDefault(a => a.Id == cinema.ActorId2)?.Name;
                ActorName3 = _actorService.GetAllActors().FirstOrDefault(a => a.Id == cinema.ActorId3)?.Name;
                ActorName4 = _actorService.GetAllActors().FirstOrDefault(a => a.Id == cinema.ActorId4)?.Name;
            }
            else
            {
                Cinema = new CinemaViewModel();
                IsEdit = false;
            }

            return Page();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для сохранения данных фильма.
        /// </summary>
        /// <returns>Результат перенаправления на страницу списка фильмов.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Если модель недействительна, загружаем списки актёров и жанров заново
                Actors = _actorService.GetAllActors();
                Genres = _genreService.GetAllGenres();
                return Page();
            }

            if (Cinema.Id > 0)
            {
                // Если ID > 0, это редактирование
                var existingCinema = _cinemaService.GetAllCinemas().FirstOrDefault(c => c.Id == Cinema.Id);
                if (existingCinema != null)
                {
                    existingCinema.Name = Cinema.Name;
                    existingCinema.Year = Cinema.Year;
                    existingCinema.Score = Cinema.Score;
                    existingCinema.ActorId1 = Cinema.ActorId1;
                    existingCinema.ActorId2 = Cinema.ActorId2;
                    existingCinema.ActorId3 = Cinema.ActorId3;
                    existingCinema.ActorId4 = Cinema.ActorId4;
                    existingCinema.GenreId1 = Cinema.GenreId1;
                    existingCinema.GenreId2 = Cinema.GenreId2;
                    existingCinema.GenreId3 = Cinema.GenreId3;

                    _cinemaService.UpdateCinema(existingCinema);
                }
            }
            else
            {
                // Если ID == 0, это добавление
                _cinemaService.AddCinema(Cinema);
            }

            // Перенаправляем на страницу списка фильмов
            return RedirectToPage("/Cinemas/Index");
        }
    }
}