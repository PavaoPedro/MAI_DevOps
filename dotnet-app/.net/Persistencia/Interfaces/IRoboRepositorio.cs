using MAIOCEAN.Models;

namespace MAIOCEAN.Persistencia.Interfaces
{
    public interface IRoboRepositorio
    {
        IEnumerable<Robo> GetAll();

        Robo GetById(int? id);

        void Add(Robo robo);

        void Update(Robo robo);

        void Delete(Robo robo);
    }
}

