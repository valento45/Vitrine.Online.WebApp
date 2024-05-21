
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.SolicitacaoOrcamento
{
    public class SolicitacaoOrcamento
    {
        public long IdSolicitacao { get; set; }
        public string NomeSolicitacao { get; set; }
        public string CelularSolicitacao { get; set; }
        public string EmailSolicitacao { get; set; }
        public string EnderecoSolicitacao { get; set; }

        public string DescricaoSolicitacao { get; set; }

        public ICollection<AnexoSolicitacaoOrcamento> Imagens { get; set; }

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;

        public SolicitacaoOrcamento()
        {
            Imagens = new List<AnexoSolicitacaoOrcamento>();
        }

        public string ObterEnderecoFormatado()
        {
            var sb = new StringBuilder();

            sb.Append(EnderecoSolicitacao);

        


            return sb.ToString();
        }



    }
}
