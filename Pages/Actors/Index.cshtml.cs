using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// ������ �������� ��� ����������� ������ ������.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// ������ ������ ��� ����������� �� ��������.
        /// </summary>
        public List<ActorViewModel> Actors { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="actorService">������ ��� ������ � �������.</param>
        public IndexModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// ������������ GET-������ ��� ����������� ������ ������.
        /// </summary>
        public void OnGet()
        {
            Actors = _actorService.GetAllActors();
        }

        /// <summary>
        /// ������������ POST-������ ��� �������� �����.
        /// </summary>
        /// <param name="id">������������� ����� ��� ��������.</param>
        /// <returns>��������� ��������������� �� �������� ������ ������.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _actorService.DeleteActor(id);
            return RedirectToPage();
        }
    }
}