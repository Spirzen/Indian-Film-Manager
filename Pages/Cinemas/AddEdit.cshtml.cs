using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Cinemas
{
    /// <summary>
    /// ������ �������� ��� ���������� ��� �������������� ������.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly CinemaService _cinemaService;
        private readonly ActorService _actorService;
        private readonly GenreService _genreService;

        /// <summary>
        /// ������ ������ ������ ��� �����.
        /// </summary>
        [BindProperty]
        public CinemaViewModel Cinema { get; set; }

        /// <summary>
        /// ������ ������ ��� ����������� ������.
        /// </summary>
        public List<ActorViewModel> Actors { get; set; }

        /// <summary>
        /// ������ ������ ��� ����������� ������.
        /// </summary>
        public List<GenreViewModel> Genres { get; set; }

        /// <summary>
        /// ����, �����������, �������� �� �������� ���������������.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="cinemaService">������ ��� ������ � ��������.</param>
        /// <param name="actorService">������ ��� ������ � �������.</param>
        /// <param name="genreService">������ ��� ������ � �������.</param>
        public AddEditModel(CinemaService cinemaService, ActorService actorService, GenreService genreService)
        {
            _cinemaService = cinemaService;
            _actorService = actorService;
            _genreService = genreService;
        }

        /// <summary>
        /// ������������ GET-������ ��� �������� ������ ������.
        /// </summary>
        /// <param name="id">������������� ������ ��� �������������� (�����������).</param>
        /// <returns>��������� ����������� ��������.</returns>
        public IActionResult OnGet(int? id)
        {
            Actors = _actorService.GetAllActors();
            Genres = _genreService.GetAllGenres();

            if (id.HasValue)
            {
                var cinema = _cinemaService.GetAllCinemas().FirstOrDefault(c => c.Id == id.Value);
                if (cinema == null)
                {
                    return NotFound();
                }
                Cinema = cinema;
                IsEdit = true;
            }
            else
            {
                Cinema = new CinemaViewModel();
                IsEdit = false;
            }
            return Page();
        }

        /// <summary>
        /// ������������ POST-������ ��� ���������� ������ ������.
        /// </summary>
        /// <returns>��������� ��������������� �� �������� ������ �������.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Actors = _actorService.GetAllActors();
                Genres = _genreService.GetAllGenres();
                return Page();
            }

            if (Cinema.Id > 0) // ���� ID > 0, ��� ��������������
            {
                var existingCinema = _cinemaService.GetAllCinemas().FirstOrDefault(c => c.Id == Cinema.Id);
                if (existingCinema != null)
                {
                    existingCinema.Name = Cinema.Name;
                    existingCinema.Year = Cinema.Year;
                    existingCinema.Score = Cinema.Score;
                    existingCinema.ActorId1 = Cinema.ActorId1;
                    existingCinema.ActorId2 = Cinema.ActorId2;
                    existingCinema.ActorId3 = Cinema.ActorId3;
                    existingCinema.ActorId4 = Cinema.ActorId4;
                    existingCinema.GenreId1 = Cinema.GenreId1;
                    existingCinema.GenreId2 = Cinema.GenreId2;
                    existingCinema.GenreId3 = Cinema.GenreId3;

                    _cinemaService.UpdateCinema(existingCinema);
                }
            }
            else // ���� ID == 0, ��� ����������
            {
                _cinemaService.AddCinema(Cinema);
            }

            return RedirectToPage("/Cinemas/Index");
        }
    }
}