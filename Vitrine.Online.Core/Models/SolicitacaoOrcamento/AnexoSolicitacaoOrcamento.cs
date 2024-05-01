using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.SolicitacaoOrcamento
{
    public class AnexoSolicitacaoOrcamento
    {
        public int Id_Anexo { get; set; }
        public long IdSolicitacao { get; set; }
        public string Anexo_Base64 { get; private set; }
        public string Extensao_Arquivo { get; private set; }



        public AnexoSolicitacaoOrcamento()
        {

        }

        public AnexoSolicitacaoOrcamento(DataRow dr)
        {

        }

        public AnexoSolicitacaoOrcamento(long idSolicitacao)
        {
            IdSolicitacao = idSolicitacao;
        }


        public void InformarAnexoBase64(string anexo)
        {
            Anexo_Base64 = anexo;
        }

        public void InformarExtensao(string extensao)
        {
            Extensao_Arquivo = extensao;
        }
    }
}

