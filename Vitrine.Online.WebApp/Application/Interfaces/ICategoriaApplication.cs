using Vitrine.Online.Core.Entities.Categoria;
using Vitrine.Online.WebApp.Models.Categoria;

namespace Vitrine.Online.WebApp.Application.Interfaces
{
    public interface ICategoriaApplication
    {
        Task<bool> Inserir(CategoriaViewModel categoria);
        Task<bool> Atualizar(CategoriaViewModel categoria);
        Task<bool> Excluir(int idCategoria);

        Task<IEnumerable<Categoria>> GetAll(int limit = 0);

    }
}
