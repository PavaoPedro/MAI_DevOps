using MAIOCEAN.Models;
using MAIOCEAN.Persistencia.Interfaces;

namespace MAIOCEAN.Persistencia.Repositorios
{
    public class RegiaoRepositorio : IRegiaoRepositorio
    {
        private readonly MAIOCEANDbContext _context;

        public RegiaoRepositorio(MAIOCEANDbContext context)
        {
            _context = context;
        }

        public void Add(Regiao regiao)
        {
            _context.Add(regiao);

            _context.SaveChanges();
        }

        public void Delete(Regiao regiao)
        {
            _context.Remove(regiao);

            _context.SaveChanges();
        }

        public IEnumerable<Regiao> GetAll()
        {
            return _context.Regiao.ToList();
        }

        public Regiao GetById(int? id)
        {
            return _context.Regiao.Find(id);
        }

        public void Update(Regiao regiao)
        {
            _context.Update(regiao);

            _context.SaveChangesAsync();
        }
    }
}

