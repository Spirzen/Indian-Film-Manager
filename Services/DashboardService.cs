using IndianFilmManager.Data;
using IndianFilmManager.Models;

namespace IndianFilmManager.Services
{
    public class DashboardService
    {
        private readonly ApplicationDbContext _context;
        private readonly CinemaService _cinemaService;

        public DashboardService(ApplicationDbContext context, CinemaService cinemaService)
        {
            _context = context;
            _cinemaService = cinemaService;
        }

        public DashboardViewModel GetDashboard()
        {
            return new DashboardViewModel
            {
                CinemaCount = _context.Cinemas.Count(),
                ActorCount = _context.Actors.Count(),
                GenreCount = _context.Genres.Count(),
                AverageScore = _cinemaService.GetAverageScore(),
                TopCinemas = _cinemaService.GetTopCinemas(5)
            };
        }
    }
}
