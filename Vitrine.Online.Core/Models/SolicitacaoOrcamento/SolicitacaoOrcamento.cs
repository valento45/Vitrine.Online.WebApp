
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.ServicosSolicitacao
{
    public class SolicitacaoOrcamento
    {
        public long Id_Solicitacao { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco_solicitacao { get; set; }

        public string Descricao_Solicitacao { get; set; }

        public ICollection<AnexoSolicitacaoOrcamento> Imagens { get; set; }

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public SolicitacaoOrcamento()
        {
            Imagens = new List<AnexoSolicitacaoOrcamento>();
        }

        public string ObterEnderecoFormatado()
        {
            var sb = new StringBuilder();

            sb.Append(Endereco_solicitacao);

        


            return sb.ToString();
        }



    }
}
