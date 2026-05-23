using IndianFilmManager.Data.Models;

namespace IndianFilmManager.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Cinemas.Any()) return;

            var actorNames = new[]
            {
                "Шахрух Хан", "Амитабх Баччан", "Аамир Хан", "Дипика Падуконе",
                "Ранвир Сингх", "Приянка Чопра", "Хритик Рошан", "Алия Бхатт"
            };
            foreach (var name in actorNames)
                context.Actors.Add(new Actor { Name = name });

            var genreNames = new[] { "Драма", "Мелодрама", "Экшен", "Комедия", "Триллер", "Приключения" };
            foreach (var name in genreNames)
                context.Genres.Add(new Genre { Name = name });

            context.SaveChanges();

            var actors = context.Actors.OrderBy(a => a.Id).ToList();
            var genres = context.Genres.OrderBy(g => g.Id).ToList();

            int A(int index) => actors[index - 1].Id;
            int G(int index) => genres[index - 1].Id;

            context.Cinemas.AddRange(
                new Cinema
                {
                    Name = "Дилвале дулхания ле джаяенге",
                    Year = 1995,
                    Score = 9,
                    ActorId1 = A(1),
                    ActorId2 = A(4),
                    GenreId1 = G(2),
                    GenreId2 = G(1),
                    GenreId3 = G(4)
                },
                new Cinema
                {
                    Name = "Три идиота",
                    Year = 2009,
                    Score = 10,
                    ActorId1 = A(3),
                    ActorId2 = A(7),
                    GenreId1 = G(4),
                    GenreId2 = G(1)
                },
                new Cinema
                {
                    Name = "Шолай",
                    Year = 1975,
                    Score = 9,
                    ActorId1 = A(2),
                    ActorId2 = A(7),
                    GenreId1 = G(3),
                    GenreId2 = G(6),
                    GenreId3 = G(1)
                },
                new Cinema
                {
                    Name = "Байрава",
                    Year = 2023,
                    Score = 7,
                    ActorId1 = A(5),
                    ActorId2 = A(4),
                    GenreId1 = G(3),
                    GenreId2 = G(5)
                },
                new Cinema
                {
                    Name = "Бархат",
                    Year = 2022,
                    Score = 8,
                    ActorId1 = A(5),
                    ActorId2 = A(8),
                    GenreId1 = G(1),
                    GenreId2 = G(4)
                },
                new Cinema
                {
                    Name = "Дон",
                    Year = 2006,
                    Score = 8,
                    ActorId1 = A(1),
                    ActorId2 = A(6),
                    GenreId1 = G(3),
                    GenreId2 = G(5)
                },
                new Cinema
                {
                    Name = "Зиндаги на милеги добара",
                    Year = 2011,
                    Score = 9,
                    ActorId1 = A(7),
                    ActorId2 = A(5),
                    ActorId3 = A(8),
                    GenreId1 = G(1),
                    GenreId2 = G(6),
                    GenreId3 = G(4)
                }
            );

            context.SaveChanges();
        }
    }
}
