namespace IndianFilmManager.Models
{
    /// <summary>
    /// Модель представления для фильма.
    /// </summary>
    public class CinemaViewModel
    {
        /// <summary>
        /// Уникальный идентификатор фильма.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год выпуска фильма.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Рейтинг фильма.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Идентификатор первого актёра.
        /// </summary>
        public int? ActorId1 { get; set; }

        /// <summary>
        /// Идентификатор второго актёра.
        /// </summary>
        public int? ActorId2 { get; set; }

        /// <summary>
        /// Идентификатор третьего актёра.
        /// </summary>
        public int? ActorId3 { get; set; }

        /// <summary>
        /// Идентификатор четвёртого актёра.
        /// </summary>
        public int? ActorId4 { get; set; }

        /// <summary>
        /// Идентификатор первого жанра.
        /// </summary>
        public int? GenreId1 { get; set; }

        /// <summary>
        /// Идентификатор второго жанра.
        /// </summary>
        public int? GenreId2 { get; set; }

        /// <summary>
        /// Идентификатор третьего жанра.
        /// </summary>
        public int? GenreId3 { get; set; }

        /// <summary>
        /// Имя первого актёра.
        /// </summary>
        public string Actor1Name { get; set; }

        /// <summary>
        /// Имя второго актёра.
        /// </summary>
        public string Actor2Name { get; set; }

        /// <summary>
        /// Имя третьего актёра.
        /// </summary>
        public string Actor3Name { get; set; }

        /// <summary>
        /// Имя четвёртого актёра.
        /// </summary>
        public string Actor4Name { get; set; }

        /// <summary>
        /// Название первого жанра.
        /// </summary>
        public string Genre1Name { get; set; }

        /// <summary>
        /// Название второго жанра.
        /// </summary>
        public string Genre2Name { get; set; }

        /// <summary>
        /// Название третьего жанра.
        /// </summary>
        public string Genre3Name { get; set; }
    }
}