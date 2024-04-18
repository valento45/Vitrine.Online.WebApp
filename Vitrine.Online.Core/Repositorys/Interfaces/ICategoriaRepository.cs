using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Entities.Categoria;

namespace Vitrine.Online.Core.Repositorys.Interfaces
{
    public interface ICategoriaRepository
    {

        Task<bool> Inserir(Categoria categoria);
        Task<bool> Atualizar(Categoria categoria);
        Task<bool> Excluir(int idCategoria);

    }
}
