using System;
using MeusFilmes.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace MeusFilmes.Servico
{
    public class ServicoFilmes
    {
        
        private static String enderecoFilmesURL = "http://my-json-server.typicode.com/adriano-carnaroli/apiMovies/filmes";
        private static String enderecoURL = "http://my-json-server.typicode.com/adriano-carnaroli/apiMovies/filmes/{0}";
        
        public ServicoFilmes()
        {
        }

        static internal async Task<List<Filme>> BuscarFilmes()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(enderecoFilmesURL);
            var filmes = JsonConvert.DeserializeObject<List<Filme>>(response);
            foreach (Filme filme in filmes)
            {
                Filme f = await App.Database.GetItemAsync(filme.id);
                if (f == null)
                {
                    await App.Database.SaveItemAsync(filme);
                }
                else
                {
                    filme.assistido = f.assistido;
                }
            }
            return filmes;
        }

        static internal async Task<Filme> BuscarFilme(int id)
        {
            HttpClient client = new HttpClient();
            String novoEnderecoURL = String.Format(enderecoURL, id);
            var response = await client.GetStringAsync(novoEnderecoURL);
            var filme = JsonConvert.DeserializeObject<Filme>(response);
            return filme;
        }
    }
}
