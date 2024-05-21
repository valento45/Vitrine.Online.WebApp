using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.services
{
    public class AnexoServicosRealizado
    {
        public int IdAnexo { get; set; }
        public long IdServico { get; set; }
        public string AnexoBase64 { get; set; }
        public string ExtensaoArquivo { get; set; }


        public AnexoServicosRealizado()
        {

        }

        public AnexoServicosRealizado(DataRow dr)
        {

        }

        public AnexoServicosRealizado(long IdServico)
        {
            this.IdServico = IdServico;
        }


        public void InformarAnexoBase64(string anexo)
        {
            AnexoBase64 = anexo;
        }

        public void InformarExtensao(string extensao)
        {
            ExtensaoArquivo = extensao;
        }
    }
}
