using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitrine.Online.Core.Entities.Categorias;
using Vitrine.Online.Core.Repositorys.Interfaces;
using Vitrine.Online.Core.Services.Intefaces;

namespace Vitrine.Online.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Inserir(Categoria categoria)
        {
            return await _categoriaRepository.Inserir(categoria);
        }

        public async Task<bool> Atualizar(Categoria categoria)
        {
            return await _categoriaRepository.Atualizar(categoria);
        }

        public async Task<bool> Excluir(int idCategoria)
        {
            return await _categoriaRepository.Excluir(idCategoria);
        }

        public async Task<IEnumerable<Categoria>> GetAll(int limit = 0)
        {
            return await _categoriaRepository.GetAll(limit);
        }


    }
}
