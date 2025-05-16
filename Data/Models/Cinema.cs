using System.ComponentModel.DataAnnotations;

namespace IndianFilmManager.Data.Models
{
    /// <summary>
    /// Модель данных для фильма.
    /// </summary>
    public class Cinema
    {
        /// <summary>
        /// Уникальный идентификатор фильма.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Год выпуска фильма.
        /// </summary>
        public int Year { get; set; }

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
        /// Рейтинг фильма.
        /// </summary>
        public int Score { get; set; }
    }
}