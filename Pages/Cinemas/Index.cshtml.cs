using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Cinemas
{
    /// <summary>
    /// Модель страницы для отображения списка фильмов.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly CinemaService _cinemaService;

        /// <summary>
        /// Список фильмов для отображения на странице.
        /// </summary>
        public List<CinemaViewModel> Cinemas { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="cinemaService">Сервис для работы с фильмами.</param>
        public IndexModel(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для отображения списка фильмов.
        /// </summary>
        public void OnGet()
        {
            Cinemas = _cinemaService.GetAllCinemas();
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