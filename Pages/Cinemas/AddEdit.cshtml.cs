using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Cinemas
{
    public class AddEditModel : PageModel
    {
        private readonly CinemaService _cinemaService;
        private readonly ActorService _actorService;
        private readonly GenreService _genreService;

        [BindProperty]
        public CinemaViewModel Cinema { get; set; } = new();

        public List<ActorViewModel> Actors { get; set; } = new();
        public List<GenreViewModel> Genres { get; set; } = new();
        public bool IsEdit { get; set; }

        public AddEditModel(CinemaService cinemaService, ActorService actorService, GenreService genreService)
        {
            _cinemaService = cinemaService;
            _actorService = actorService;
            _genreService = genreService;
        }

        public IActionResult OnGet(int? id)
        {
            Actors = _actorService.GetAllActors();
            Genres = _genreService.GetAllGenres();

            if (id.HasValue)
            {
                var cinema = _cinemaService.GetCinemaById(id.Value);
                if (cinema == null)
                    return NotFound();

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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Actors = _actorService.GetAllActors();
                Genres = _genreService.GetAllGenres();
                IsEdit = Cinema.Id > 0;
                return Page();
            }

            if (Cinema.Id > 0)
                _cinemaService.UpdateCinema(Cinema);
            else
                _cinemaService.AddCinema(Cinema);

            return RedirectToPage("/Cinemas/Index");
        }
    }
}
