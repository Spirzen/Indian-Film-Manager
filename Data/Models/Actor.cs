using System.ComponentModel.DataAnnotations;

namespace IndianFilmManager.Data.Models
{
    /// <summary>
    /// Модель данных для актёра.
    /// </summary>
    public class Actor
    {
        /// <summary>
        /// Уникальный идентификатор актёра.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя актёра.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}