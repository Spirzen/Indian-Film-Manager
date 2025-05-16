using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Pages.Actors
{
    /// <summary>
    /// ������ �������� ��� ������ ������.
    /// </summary>
    public class SearchModel : PageModel
    {
        private readonly ActorService _actorService;

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="SearchModel"/>.
        /// </summary>
        /// <param name="actorService">������ ��� ������ � �������.</param>
        public SearchModel(ActorService actorService)
        {
            _actorService = actorService;
        }

        /// <summary>
        /// ������������ GET-������ ��� ������ ������ �� �����.
        /// </summary>
        /// <param name="query">������ ������� ��� ������ ������.</param>
        /// <returns>JSON-����� � ���������� �������.</returns>
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