namespace IndianFilmManager.Models
{
    public class DashboardViewModel
    {
        public int CinemaCount { get; set; }
        public int ActorCount { get; set; }
        public int GenreCount { get; set; }
        public double AverageScore { get; set; }
        public List<CinemaViewModel> TopCinemas { get; set; } = new();
    }
}
