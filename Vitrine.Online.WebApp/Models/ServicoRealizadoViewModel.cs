using Vitrine.Online.Core.Entities.Categorias;

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


        public IEnumerable<Vitrine.Online.Core.Entities.Categorias.Categoria> Categorias { get; set; }
        public ServicoRealizadoViewModel()
        {
            Anexos = new List<IFormFile>();
        }
    }
}
