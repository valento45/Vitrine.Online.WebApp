using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Entities.Categorias;

namespace Vitrine.Online.Core.Services.Intefaces
{
    public interface ICategoriaService
    {
        Task<bool> Inserir(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Excluir(int idCategoria);

        Task<IEnumerable<Categoria>> GetAll(int limit = 0);
    }
}
