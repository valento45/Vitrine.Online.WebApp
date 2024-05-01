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

        public long Id_Servico { get; set; }
        public long Id_Catalogo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Hora { get; set; }
        public string Resumo { get; set; }
        public string Endereco { get; set; }
     


        public ICollection<AnexoServicosRealizado> Imagens { get; set; }


        public ServicosRealizado()
        {
            Imagens = new List<AnexoServicosRealizado>();
        }


        public ServicosRealizado(DataRow dr)
        {

        }


        public void InformarAnexo(AnexoServicosRealizado anexoTrabalhoRealizado)
        {
            if (Imagens == null)
                Imagens = new List<AnexoServicosRealizado>();

            Imagens.Add(anexoTrabalhoRealizado);
        }


       
    }
}
