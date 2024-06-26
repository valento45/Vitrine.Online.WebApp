﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitrine.Online.Core.Entities.Categorias
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public string ImagemBase64 { get; set; }
        public Categoria()
        {

        }

        public Categoria(DataRow dr)
        {
            IdCategoria = int.Parse(dr["IdCategoria"]?.ToString() ?? "");
            NomeCategoria = dr["NomeCategoria"]?.ToString() ?? "";
            Descricao = dr["Descricao"]?.ToString() ?? "";
            ImagemBase64 = dr["ImagemBase64"]?.ToString() ?? "";
        }


    }
}
