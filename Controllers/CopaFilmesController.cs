using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers
{
    [Route("api/[controller]")]
    public class CopaFilmesController : Controller
    {
        public Torneio GerarTorneio(List<Filme> filmes)
        {
            Torneio result = new Torneio();

            filmes.Sort((x,y) => x.Titulo.CompareTo(y.Titulo));
            result.Oitavas = filmes;

            result.Quartas = new List<Filme>
            {
                CompararNotas(filmes.ElementAt(0), filmes.ElementAt(7)), // Bracket A: 1st vs 8th
                CompararNotas(filmes.ElementAt(1), filmes.ElementAt(6)), // Bracket B: 2nd vs 7th
                CompararNotas(filmes.ElementAt(2), filmes.ElementAt(5)), // Bracket C: 3rd vs 6th
                CompararNotas(filmes.ElementAt(3), filmes.ElementAt(4))  // Bracket D: 4th vs 5th
            };
            result.Semifinal = new List<Filme>
            {
                CompararNotas(result.Quartas.ElementAt(0), result.Quartas.ElementAt(1)), // Bracket A vs B
                CompararNotas(result.Quartas.ElementAt(2), result.Quartas.ElementAt(3)), // Bracket C vs D
            };

            // Para decidir a final, basta dar um Sort Descending na Semifinal.
            result.PrimeiroLugar = CompararNotas(result.Semifinal.ElementAt(0), result.Semifinal.ElementAt(1));

            return result;
        }

        /// <summary>
        /// Calcula um torneio de chaves entre os 8 filmes passados, retornando o campeão e vice-campeão respectivamente.
        /// </summary>
        [HttpPost("[action]")]
        public List<Filme> TorneioSimples([FromBody] List<Filme> filmes)
        {
            Torneio result = GerarTorneio(filmes);
            return result.Semifinal;
        }

        /// <summary>
        /// Calcula um torneio de chaves entre os 8 filmes passados, retornando um objeto com detalhes sobre cada chave.
        /// </summary>
        [HttpPost("[action]")]
        public Torneio TorneioCompleto([FromBody] List<Filme> filmes)
        {
            Torneio result = GerarTorneio(filmes);
            return result;
        }

        private Filme CompararNotas(Filme filmeA, Filme filmeB)
        {
            if (filmeA.Nota >= filmeB.Nota)
            {
                return filmeA;
            } else {
                return filmeB;
            }
        }

        public class Filme
        {
            public string Id { get; set; }
            public string Titulo { get; set; }
            public int Ano { get; set; }
            public double Nota { get; set; }
        }

        public class Torneio
        {
            public List<Filme> Oitavas { get; set; }
            public List<Filme> Quartas { get; set; }
            public List<Filme> Semifinal { get; set; }
            public Filme PrimeiroLugar { get; set; }
            public Filme SegundoLugar { get; set; }
        }
    }
}