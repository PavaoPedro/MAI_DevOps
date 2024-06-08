using MAIOCEAN.Models;

namespace MAIOCEAN.Persistencia.Interfaces
{
    public interface ITemperaturaRepositorio
    {
        IEnumerable<Temperatura> GetAll();

        Temperatura GetById(int? id);

        void Add(Temperatura temperatura);

        void Update(Temperatura temperatura);

        void Delete(Temperatura temperatura);
    }
}

