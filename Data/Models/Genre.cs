using System.ComponentModel.DataAnnotations;

namespace IndianFilmManager.Data.Models
{
    /// <summary>
    /// Модель данных для жанра.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Уникальный идентификатор жанра.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название жанра.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}