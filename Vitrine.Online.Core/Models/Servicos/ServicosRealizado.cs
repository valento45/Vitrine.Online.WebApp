using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Models.services
{
    public class ServicosRealizado
    {

        public long   IdServico { get; set; }
        public long IdCategoria { get; set; }
        public string DescricaoServico { get; set; }
        public DateTime DataServico { get; set; }
        public string ResumoServico { get; set; }
        public string EnderecoServico { get; set; }
     
        public ICollection<AnexoServicosRealizado> Imagens { get; set; }


        public ServicosRealizado()
        {
            Imagens = new List<AnexoServicosRealizado>();
        }


        public ServicosRealizado(DataRow dr)
        {

        }


        public void InformarAnexo(AnexoServicosRealizado anexoServicosRealizado)
        {
            if (Imagens == null)
                Imagens = new List<AnexoServicosRealizado>();

            Imagens.Add(anexoServicosRealizado);
        }



    }
}
