using MAIOCEAN.Models;
using MAIOCEAN.Persistencia.Interfaces;

namespace MAIOCEAN.Persistencia.Repositorios
{
    public class RoboRepositorio : IRoboRepositorio
    {
        private readonly MAIOCEANDbContext _context;

        public RoboRepositorio(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public void Add(Robo robo)
        {
            _context.Add(robo);

            _context.SaveChanges();
        }

        public void Delete(Robo robo)
        {
            _context.Remove(robo);

            _context.SaveChanges();
        }

        public IEnumerable<Robo> GetAll()
        {
            return _context.Robo.ToList();
        }

        public Robo GetById(int? id)
        {
            return _context.Robo.Find(id);
        }

        public void Update(Robo robo)
        {
            _context.Update(robo);

            _context.SaveChangesAsync();
        }
    }
}

