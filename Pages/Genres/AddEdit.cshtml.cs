using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Genres
{
    /// <summary>
    /// Модель страницы для добавления или редактирования жанра.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly GenreService _genreService;

        /// <summary>
        /// Модель данных жанра для формы.
        /// </summary>
        [BindProperty]
        public GenreViewModel Genre { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли операция редактированием.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="genreService">Сервис для работы с жанрами.</param>
        public AddEditModel(GenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных жанра.
        /// </summary>
        /// <param name="id">Идентификатор жанра для редактирования (опционально).</param>
        /// <returns>Результат отображения страницы.</returns>
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                var genre = _genreService.GetAllGenres().FirstOrDefault(g => g.Id == id.Value);
                if (genre == null)
                {
                    return NotFound();
                }

                Genre = genre;
                IsEdit = true;
            }
            else
            {
                Genre = new GenreViewModel();
                IsEdit = false;
            }

            return Page();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для сохранения данных жанра.
        /// </summary>
        /// <returns>Результат перенаправления на страницу списка жанров.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Genre.Id > 0)
            {
                // Если ID > 0, это редактирование
                var existingGenre = _genreService.GetAllGenres().FirstOrDefault(g => g.Id == Genre.Id);
                if (existingGenre != null)
                {
                    existingGenre.Name = Genre.Name;
                    _genreService.UpdateGenre(existingGenre);
                }
            }
            else
            {
                // Если ID == 0, это добавление
                _genreService.AddGenre(Genre);
            }

            return RedirectToPage("/Genres/Index");
        }
    }
}