using IndianFilmManager.Models;
using IndianFilmManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndianFilmManager.Pages.Cinemas
{
    public class IndexModel : PageModel
    {
        private readonly CinemaService _cinemaService;

        public List<CinemaViewModel> Cinemas { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        public IndexModel(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public void OnGet()
        {
            Cinemas = _cinemaService.GetAllCinemas(Search);
        }

        public IActionResult OnPostDelete(int id)
        {
            _cinemaService.DeleteCinema(id);
            return RedirectToPage(new { Search });
        }
    }
}
