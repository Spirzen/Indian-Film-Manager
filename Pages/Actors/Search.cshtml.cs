using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// Модель страницы для поиска актёров.
    /// </summary>
    public class SearchModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="SearchModel"/>.
        /// </summary>
        /// <param name="actorService">Сервис для работы с актёрами.</param>
        public SearchModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для поиска актёров по имени.
        /// </summary>
        /// <param name="query">Строка запроса для поиска актёров.</param>
        /// <returns>JSON-ответ с найденными актёрами.</returns>
        public IActionResult OnGet(string query)
        {
            var actors = _actorService.GetAllActors()
                .Where(a => a.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                .Take(10)
                .Select(a => new { id = a.Id, name = a.Name })
                .ToList();

            return new JsonResult(actors);
        }
    }
}