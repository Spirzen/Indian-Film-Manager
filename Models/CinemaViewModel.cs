namespace IndianFilmManager.Models
{
    /// <summary>
    /// Модель представления для фильма.
    /// </summary>
    public class CinemaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int? ActorId1 { get; set; }
        public int? ActorId2 { get; set; }
        public int? ActorId3 { get; set; }
        public int? ActorId4 { get; set; }
        public int? GenreId1 { get; set; }
        public int? GenreId2 { get; set; }
        public int? GenreId3 { get; set; }
        public int Score { get; set; }
    }
}