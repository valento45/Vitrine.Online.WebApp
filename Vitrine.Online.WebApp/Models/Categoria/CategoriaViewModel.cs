namespace Vitrine.Online.WebApp.Models.Categoria
{
    public class CategoriaViewModel
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public IFormFile ImagemAnexo { get; set; }
    }
}
