using Vitrine.Online.Core.Models.SolicitacaoOrcamento;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Vitrine.Online.WebApp.Models
{
    public class SolicitacaoOrcamentoViewModel
    {
        public long IdSolicitacao { get; set; }
        public string NomeSolicitacao { get; set; }
        public string CelularSolicitacao { get; set; }
        public string EmailSolicitacao { get; set; }
        public string EnderecoSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public List<IFormFile> Anexos { get; set; }

        public SolicitacaoOrcamentoViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public string ObterEnderecoFormatado()
        {
            return $"{EnderecoSolicitacao}";
        }
    }
}
