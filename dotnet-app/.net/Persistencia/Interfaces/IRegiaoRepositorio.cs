using MAIOCEAN.Models;

namespace MAIOCEAN.Persistencia.Interfaces
{
    public interface IRegiaoRepositorio
    {
        IEnumerable<Regiao> GetAll();

        Regiao GetById(int? id);

        void Add(Regiao regiao);

        void Update(Regiao regiao);

        void Delete(Regiao regiao);
    }
}

