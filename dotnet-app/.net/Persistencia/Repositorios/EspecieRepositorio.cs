using MAIOCEAN.Models;
using MAIOCEAN.Persistencia.Interfaces;

namespace MAIOCEAN.Persistencia.Repositorios
{
    public class EspecieRepositorio : IEspecieRepositorio
    {
        private readonly MAIOCEANDbContext _context;

        public EspecieRepositorio(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public void Add(Especie especie)
        {
            _context.Add(especie);

            _context.SaveChanges();
        }

        public void Delete(Especie especie)
        {
            _context.Remove(especie);

            _context.SaveChanges();
        }

        public IEnumerable<Especie> GetAll()
        {
            return _context.Especie.ToList();
        }

        public Especie GetById(int? id)
        {
            return _context.Especie.Find(id);
        }

        public void Update(Especie especie)
        {
            _context.Update(especie);

            _context.SaveChangesAsync();
        }
    }
}

