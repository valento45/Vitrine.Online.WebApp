using Vitrine.Online.Core.Entities.Categoria;
using Vitrine.Online.Core.Services.Intefaces;
using Vitrine.Online.WebApp.Application.Interfaces;
using Vitrine.Online.WebApp.Models.Categoria;
using Vitrine.Online.Core.Extensions;

namespace Vitrine.Online.WebApp.Application
{
    public class CategoriaApplication : ICategoriaApplication
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaApplication(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<bool> Inserir(CategoriaViewModel categoria)
        {
            var request = new Categoria
            {
                IdCategoria = categoria.IdCategoria,
                Descricao = categoria.Descricao,
                NomeCategoria = categoria.NomeCategoria,
                ImagemBase64 = await categoria.ImagemAnexo.GetBase64FromFile()
            };

            return await _categoriaService.Inserir(request);
        }

        public async Task<bool> Atualizar(CategoriaViewModel categoria)
        {
            var request = new Categoria
            {
                IdCategoria = categoria.IdCategoria,
                Descricao = categoria.Descricao,
                NomeCategoria = categoria.NomeCategoria,
                ImagemBase64 = await categoria.ImagemAnexo.GetBase64FromFile()
            };

            return await _categoriaService.Atualizar(request);
        }

        public async Task<bool> Excluir(int idCategoria)
        {
            return await _categoriaService.Excluir(idCategoria);
        }

        public async Task<IEnumerable<Categoria>> GetAll(int limit = 0)
        {
            return await _categoriaService.GetAll(limit);
        }


    }
}
