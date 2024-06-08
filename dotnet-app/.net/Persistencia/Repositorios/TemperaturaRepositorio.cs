using MAIOCEAN.Models;
using MAIOCEAN.Persistencia.Interfaces;

namespace MAIOCEAN.Persistencia.Repositorios
{
    public class TemperaturaRepositorio :ITemperaturaRepositorio

    {
        private readonly MAIOCEANDbContext _context;

        public TemperaturaRepositorio(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public void Add(Temperatura temperatura)
        {
            _context.Add(temperatura);

            _context.SaveChanges();
        }

        public void Delete(Temperatura temperatura)
        {
            _context.Remove(temperatura);

            _context.SaveChanges();
        }

        public IEnumerable<Temperatura> GetAll()
        {
            return _context.Temperatura.ToList();
        }

        public Temperatura GetById(int? id)
        {
            return _context.Temperatura.Find(id);
        }

        public void Update(Temperatura temperatura)
        {
            _context.Update(temperatura);

            _context.SaveChangesAsync();
        }
    }
}

