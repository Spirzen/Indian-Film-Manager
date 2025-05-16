using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Genres
{
    /// <summary>
    /// ������ �������� ��� ���������� ��� �������������� �����.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly GenreService _genreService;

        /// <summary>
        /// ������ ������ ����� ��� �����.
        /// </summary>
        [BindProperty]
        public GenreViewModel Genre { get; set; }

        /// <summary>
        /// ����, �����������, �������� �� �������� ���������������.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="genreService">������ ��� ������ � �������.</param>
        public AddEditModel(GenreService genreService)
        {
            _genreService = genreService;
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
        /// ������������ POST-������ ��� ���������� ������ �����.
        /// </summary>
        /// <returns>��������� ��������������� �� �������� ������ ������.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Genre.Id > 0)
            {
                // ���� ID > 0, ��� ��������������
                var existingGenre = _genreService.GetAllGenres().FirstOrDefault(g => g.Id == Genre.Id);
                if (existingGenre != null)
                {
                    existingGenre.Name = Genre.Name;
                    _genreService.UpdateGenre(existingGenre);
                }
            }
            else
            {
                // ���� ID == 0, ��� ����������
                _genreService.AddGenre(Genre);
            }

            return RedirectToPage("/Genres/Index");
        }
    }
}