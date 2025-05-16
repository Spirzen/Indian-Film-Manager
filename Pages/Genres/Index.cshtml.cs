using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace IndianFilmManager.Pages.Genres
{
    /// <summary>
    /// ������ �������� ��� ����������� ������ ������.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly GenreService _genreService;

        /// <summary>
        /// ������ ������ ��� ����������� �� ��������.
        /// </summary>
        public List<GenreViewModel> Genres { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="genreService">������ ��� ������ � �������.</param>
        public IndexModel(GenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// ������������ GET-������ ��� �������� ������ ������.
        /// </summary>
        public void OnGet()
        {
            Genres = _genreService.GetAllGenres();
        }

        /// <summary>
        /// ������������ POST-������ ��� �������� �����.
        /// </summary>
        /// <param name="id">������������� ����� ��� ��������.</param>
        /// <returns>��������� ��������������� �� �������� ������ ������.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _genreService.DeleteGenre(id);
            return RedirectToPage();
        }
    }
}