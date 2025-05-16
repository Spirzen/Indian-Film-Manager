using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// ������ �������� ��� ���������� ��� �������������� �����.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// ������ ������ ����� ��� �����.
        /// </summary>
        [BindProperty]
        public ActorViewModel Actor { get; set; }

        /// <summary>
        /// ����, �����������, �������� �� �������� ���������������.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="actorService">������ ��� ������ � �������.</param>
        public AddEditModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// ������������ GET-������ ��� �������� ������ �����.
        /// </summary>
        /// <param name="id">������������� ����� ��� �������������� (�����������).</param>
        /// <returns>��������� ����������� ��������.</returns>
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
        /// ������������ POST-������ ��� ���������� ������ �����.
        /// </summary>
        /// <returns>��������� ��������������� �� �������� ������ ������.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Actor.Id > 0)
            {
                // ���� ID > 0, ��� ��������������
                var existingActor = _actorService.GetAllActors().FirstOrDefault(a => a.Id == Actor.Id);
                if (existingActor != null)
                {
                    existingActor.Name = Actor.Name;
                    _actorService.UpdateActor(existingActor);
                }
            }
            else
            {
                // ���� ID == 0, ��� ����������
                _actorService.AddActor(Actor);
            }

            return RedirectToPage("/Actors/Index");
        }
    }
}