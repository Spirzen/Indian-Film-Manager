using IndianFilmManager.Data;
using IndianFilmManager.Data.Models;
using IndianFilmManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IndianFilmManager.Services
{
    public class CinemaService
    {
        private readonly ApplicationDbContext _context;

        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CinemaViewModel> GetAllCinemas(string? search = null)
        {
            var query = _context.Cinemas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                query = query.Where(c => c.Name.Contains(term));
            }

            var cinemas = query.OrderByDescending(c => c.Score).ThenByDescending(c => c.Year).ToList();
            return MapCinemas(cinemas);
        }

        public List<CinemaViewModel> GetTopCinemas(int count = 5)
        {
            var cinemas = _context.Cinemas
                .OrderByDescending(c => c.Score)
                .ThenByDescending(c => c.Year)
                .Take(count)
                .ToList();

            return MapCinemas(cinemas);
        }

        public CinemaViewModel? GetCinemaById(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            return cinema == null ? null : MapCinemas(new List<Cinema> { cinema }).First();
        }

        public void AddCinema(CinemaViewModel cinema)
        {
            _context.Cinemas.Add(MapToEntity(cinema));
            _context.SaveChanges();
        }

        public void UpdateCinema(CinemaViewModel cinema)
        {
            var existing = _context.Cinemas.Find(cinema.Id);
            if (existing == null) return;

            existing.Name = cinema.Name;
            existing.Year = cinema.Year;
            existing.ActorId1 = cinema.ActorId1;
            existing.ActorId2 = cinema.ActorId2;
            existing.ActorId3 = cinema.ActorId3;
            existing.ActorId4 = cinema.ActorId4;
            existing.GenreId1 = cinema.GenreId1;
            existing.GenreId2 = cinema.GenreId2;
            existing.GenreId3 = cinema.GenreId3;
            existing.Score = cinema.Score;
            _context.SaveChanges();
        }

        public void DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null) return;

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
        }

        public double GetAverageScore()
        {
            if (!_context.Cinemas.Any()) return 0;
            return Math.Round(_context.Cinemas.Average(c => c.Score), 1);
        }

        private List<CinemaViewModel> MapCinemas(List<Cinema> cinemas)
        {
            var actors = _context.Actors.AsNoTracking().ToDictionary(a => a.Id, a => a.Name);
            var genres = _context.Genres.AsNoTracking().ToDictionary(g => g.Id, g => g.Name);

            return cinemas.Select(c =>
            {
                var vm = new CinemaViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Year = c.Year,
                    ActorId1 = c.ActorId1,
                    ActorId2 = c.ActorId2,
                    ActorId3 = c.ActorId3,
                    ActorId4 = c.ActorId4,
                    GenreId1 = c.GenreId1,
                    GenreId2 = c.GenreId2,
                    GenreId3 = c.GenreId3,
                    Score = c.Score
                };

                vm.ActorsDisplay = FormatNames(actors, c.ActorId1, c.ActorId2, c.ActorId3, c.ActorId4);
                vm.GenresDisplay = FormatNames(genres, c.GenreId1, c.GenreId2, c.GenreId3);
                return vm;
            }).ToList();
        }

        private static string FormatNames(Dictionary<int, string> lookup, params int?[] ids)
        {
            var names = ids
                .Where(id => id.HasValue && lookup.ContainsKey(id.Value))
                .Select(id => lookup[id!.Value])
                .Distinct()
                .ToList();

            return names.Count > 0 ? string.Join(", ", names) : "—";
        }

        private static Cinema MapToEntity(CinemaViewModel cinema) => new()
        {
            Name = cinema.Name,
            Year = cinema.Year,
            ActorId1 = cinema.ActorId1,
            ActorId2 = cinema.ActorId2,
            ActorId3 = cinema.ActorId3,
            ActorId4 = cinema.ActorId4,
            GenreId1 = cinema.GenreId1,
            GenreId2 = cinema.GenreId2,
            GenreId3 = cinema.GenreId3,
            Score = cinema.Score
        };
    }
}
