namespace Vitrine.Online.WebApp.Models
{
    public class ServicosViewModel
    {
        public long Id_Servico { get; set; }
        public long Id_Catalogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public string Resumo { get; set; }
        public string Local { get; set; }

        public List<IFormFile> Anexos { get; set; }



        public ServicosViewModel()
        {
            Anexos = new List<IFormFile>();
        }
    }
}
