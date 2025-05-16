using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Cinemas
{
    /// <summary>
    /// ������ �������� ��� ����������� ������ �������.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly CinemaService _cinemaService;

        /// <summary>
        /// ������ ������� ��� ����������� �� ��������.
        /// </summary>
        public List<CinemaViewModel> Cinemas { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="cinemaService">������ ��� ������ � ��������.</param>
        public IndexModel(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        /// <summary>
        /// ������������ GET-������ ��� ����������� ������ �������.
        /// </summary>
        public void OnGet()
        {
            Cinemas = _cinemaService.GetAllCinemas();
        }

        /// <summary>
        /// ������������ POST-������ ��� �������� ������.
        /// </summary>
        /// <param name="id">������������� ������ ��� ��������.</param>
        /// <returns>��������� ��������������� �� �������� ������ �������.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _cinemaService.DeleteCinema(id);
            return RedirectToPage();
        }
    }
}