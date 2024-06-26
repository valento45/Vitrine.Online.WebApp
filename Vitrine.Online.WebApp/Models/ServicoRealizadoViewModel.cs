﻿using Vitrine.Online.Core.Entities.Categorias;
using Vitrine.Online.Core.Models.services;

namespace Vitrine.Online.WebApp.Models
{
    public class ServicoRealizadoViewModel
    {
        public long IdServico { get; set; }
        public long IdCategoria { get; set; }
        public string DescricaoServico { get; set; }
        public DateTime DataServico { get; set; }
        public string ResumoServico { get; set; }
        public string EnderecoServico { get; set; }

        public List<IFormFile> Anexos { get; set; }
        public ICollection<AnexoServicosRealizado> Imagens { get; set; }

        public IEnumerable<Vitrine.Online.Core.Entities.Categorias.Categoria> Categorias { get; set; }

        public Vitrine.Online.Core.Entities.Categorias.Categoria ObterCategoria()
        {
            var categoria = Categorias?.FirstOrDefault(x => x.IdCategoria == IdCategoria) ?? new Core.Entities.Categorias.Categoria();

            return categoria;
        }



        public ServicoRealizadoViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public ServicoRealizadoViewModel(ServicosRealizado servicosRealizado)
        {
            IdServico = servicosRealizado.IdServico;
            IdCategoria = servicosRealizado.IdCategoria;
            DescricaoServico = servicosRealizado.DescricaoServico;
            DataServico = servicosRealizado.DataServico;
            ResumoServico = servicosRealizado.ResumoServico;
            EnderecoServico = servicosRealizado.EnderecoServico;
            Imagens = servicosRealizado.Imagens;
        }
    }
}
