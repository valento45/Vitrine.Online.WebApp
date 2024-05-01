using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.TrabalhosRealizados
{
    public class AnexoServicosRealizado
    {
        public int Id_Anexo { get; set; }
        public long Id_Portfolio { get; set; }
        public string Anexo_Base64 { get; set; }
        public string Extensao_Arquivo { get; set; }


        public AnexoServicosRealizado()
        {

        }

        public AnexoServicosRealizado(DataRow dr)
        {

        }

        public AnexoServicosRealizado(long idPortfolio)
        {
            Id_Portfolio = idPortfolio;
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
