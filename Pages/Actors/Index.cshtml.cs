using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// Модель страницы для отображения списка актёров.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// Список актёров для отображения на странице.
        /// </summary>
        public List<ActorViewModel> Actors { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="actorService">Сервис для работы с актёрами.</param>
        public IndexModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для отображения списка актёров.
        /// </summary>
        public void OnGet()
        {
            Actors = _actorService.GetAllActors();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для удаления актёра.
        /// </summary>
        /// <param name="id">Идентификатор актёра для удаления.</param>
        /// <returns>Результат перенаправления на страницу списка актёров.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _actorService.DeleteActor(id);
            return RedirectToPage();
        }
    }
}