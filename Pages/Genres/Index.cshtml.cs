using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Genres
{
    /// <summary>
    /// Модель страницы для отображения списка жанров.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly GenreService _genreService;

        /// <summary>
        /// Список жанров для отображения на странице.
        /// </summary>
        public List<GenreViewModel> Genres { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="genreService">Сервис для работы с жанрами.</param>
        public IndexModel(GenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных жанров.
        /// </summary>
        public void OnGet()
        {
            Genres = _genreService.GetAllGenres();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для удаления жанра.
        /// </summary>
        /// <param name="id">Идентификатор жанра для удаления.</param>
        /// <returns>Результат перенаправления на страницу списка жанров.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _genreService.DeleteGenre(id);
            return RedirectToPage();
        }
    }
}