using IndianFilmManager.Data;
using IndianFilmManager.Data.Models;
using IndianFilmManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace IndianFilmManager.Services
{
    /// <summary>
    /// Сервис для работы с актёрами.
    /// </summary>
    public class ActorService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ActorService"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех актёров.
        /// </summary>
        /// <returns>Список моделей представления актёров.</returns>
        public List<ActorViewModel> GetAllActors()
        {
            return _context.Actors
                .Select(a => new ActorViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }

        /// <summary>
        /// Добавляет нового актёра в базу данных.
        /// </summary>
        /// <param name="actor">Модель представления актёра для добавления.</param>
        public void AddActor(ActorViewModel actor)
        {
            var newActor = new Actor { Name = actor.Name };
            _context.Actors.Add(newActor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет данные существующего актёра.
        /// </summary>
        /// <param name="actor">Модель представления актёра для обновления.</param>
        public void UpdateActor(ActorViewModel actor)
        {
            var existingActor = _context.Actors.Find(actor.Id);
            if (existingActor != null)
            {
                existingActor.Name = actor.Name;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет актёра из базы данных по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор актёра для удаления.</param>
        public void DeleteActor(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                _context.SaveChanges();
            }
        }
    }
}