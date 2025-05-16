using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// Модель страницы для добавления или редактирования актёра.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// Модель данных актёра для формы.
        /// </summary>
        [BindProperty]
        public ActorViewModel Actor { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли операция редактированием.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="actorService">Сервис для работы с актёрами.</param>
        public AddEditModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных актёра.
        /// </summary>
        /// <param name="id">Идентификатор актёра для редактирования (опционально).</param>
        /// <returns>Результат отображения страницы.</returns>
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                var actor = _actorService.GetAllActors().FirstOrDefault(a => a.Id == id.Value);
                if (actor == null)
                {
                    return NotFound();
                }
                Actor = actor;
                IsEdit = true;
            }
            else
            {
                Actor = new ActorViewModel();
                IsEdit = false;
            }
            return Page();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для сохранения данных актёра.
        /// </summary>
        /// <returns>Результат перенаправления на страницу списка актёров.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Actor.Id > 0)
            {
                // Если ID > 0, это редактирование
                var existingActor = _actorService.GetAllActors().FirstOrDefault(a => a.Id == Actor.Id);
                if (existingActor != null)
                {
                    existingActor.Name = Actor.Name;
                    _actorService.UpdateActor(existingActor);
                }
            }
            else
            {
                // Если ID == 0, это добавление
                _actorService.AddActor(Actor);
            }

            return RedirectToPage("/Actors/Index");
        }
    }
}