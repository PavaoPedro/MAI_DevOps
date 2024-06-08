using MAIOCEAN.Models;

namespace MAIOCEAN.Persistencia.Interfaces
{
    public interface IEspecieRepositorio
    {
        IEnumerable<Especie> GetAll();

        Especie GetById(int? id);

        void Add(Especie especie);

        void Update(Especie especie);

        void Delete(Especie especie);
    }
}

