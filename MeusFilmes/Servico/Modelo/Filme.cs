using System;
using SQLite;

namespace MeusFilmes.Servico.Modelo
{
    public class Filme
    {
        [PrimaryKey]
        public int id { get; set; }
        public String titulo { get; set; }
        public String ano { get; set; }
        public String genero { get; set; }
        public String titulo_original { get; set; }
        public String idioma_original { get; set; }
        public String capa { get; set; }
        public String fundo { get; set; }
        public String sinopse { get; set; }
        public Boolean assistido { get; set; }
    }
}