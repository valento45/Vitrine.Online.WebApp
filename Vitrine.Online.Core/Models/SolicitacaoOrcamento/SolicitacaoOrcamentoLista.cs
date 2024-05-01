using Vitrine.Online.Core.Models.ServicosSolicitacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.ServicosSolicitacao
{
    public class SolicitacaoOrcamentoLista
    {
        public IEnumerable<SolicitacaoOrcamento> ListaSolicitacoes { get; set; }
    }
}
