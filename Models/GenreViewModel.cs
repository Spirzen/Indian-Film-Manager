namespace IndianFilmManager.Models
{
    /// <summary>
    /// Модель представления для жанра.
    /// </summary>
    public class GenreViewModel
    {
        /// <summary>
        /// Идентификатор жанра (первичный ключ).
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название жанра.
        /// </summary>
        public string Name { get; set; }
    }
}