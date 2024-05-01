using Vitrine.Online.Core.Models.ServicosSolicitacao;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Vitrine.Online.WebApp.Models
{
    public class SolicitacaoOrcamentoViewModel
    {
        public long Id_Solicitacao { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco_solicitacao { get; set; }
        public string Descricao_Solicitacao { get; set; }

        public List<IFormFile> Anexos { get; set; }

        public SolicitacaoOrcamentoViewModel()
        {
            Anexos = new List<IFormFile>();
        }

        public string ObterEnderecoFormatado()
        {
            return $"{Endereco_solicitacao}";
        }
    }
}
