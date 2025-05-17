namespace IndianFilmManager.Models
{
    /// <summary>
    /// Модель представления для актёра.
    /// </summary>
    public class ActorViewModel
    {
        /// <summary>
        /// Идентификатор актёра (первичный ключ).
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя актёра (полное).
        /// </summary>
        public string Name { get; set; }
    }
}