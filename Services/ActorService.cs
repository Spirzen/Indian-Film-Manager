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

        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public void AddActor(ActorViewModel actor)
        {
            var newActor = new Actor { Name = actor.Name };
            _context.Actors.Add(newActor);
            _context.SaveChanges();
        }

        public void UpdateActor(ActorViewModel actor)
        {
            var existingActor = _context.Actors.Find(actor.Id);
            if (existingActor != null)
            {
                existingActor.Name = actor.Name;
                _context.SaveChanges();
            }
        }

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