using MAIOCEAN.Models;

namespace MAIOCEAN.Persistencia.Interfaces
{
    public interface IImagemRepositorio
    {
        IEnumerable<Imagem> GetAll();

        Imagem GetById(int? id);

        void Add(Imagem imagem);

        void Update(Imagem imagem);

        void Delete(Imagem imagem);
    }
}

