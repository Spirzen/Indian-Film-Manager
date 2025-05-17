namespace IndianFilmManager.Models
{
    /// <summary>
    /// Модель представления для фильма.
    /// </summary>
    public class CinemaViewModel
    {
        /// <summary>
        /// Идентификатор фильма (первичный ключ).
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название фильма.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Год выпуска.
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Идентификатор актера (внешний ключ).
        /// </summary>
        public int? ActorId1 { get; set; }
        /// <summary>
        /// Идентификатор актера (внешний ключ).
        /// </summary>
        public int? ActorId2 { get; set; }
        /// <summary>
        /// Идентификатор актера (внешний ключ).
        /// </summary>
        public int? ActorId3 { get; set; }
        /// <summary>
        /// Идентификатор актера (внешний ключ).
        /// </summary>
        public int? ActorId4 { get; set; }
        /// <summary>
        /// Идентификатор жанра (внешний ключ).
        /// </summary>
        public int? GenreId1 { get; set; }
        /// <summary>
        /// Идентификатор жанра (внешний ключ).
        /// </summary>
        public int? GenreId2 { get; set; }
        /// <summary>
        /// Идентификатор жанра (внешний ключ).
        /// </summary>
        public int? GenreId3 { get; set; }
        /// <summary>
        /// Оценка.
        /// </summary>
        public int Score { get; set; }
    }
}