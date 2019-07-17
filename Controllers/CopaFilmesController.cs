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
            result.Quartas = filmes;

            result.Semifinal = new List<Filme>
            {
                CompararNotas(filmes.ElementAt(0), filmes.ElementAt(7)), // Bracket A: 1st vs 8th
                CompararNotas(filmes.ElementAt(1), filmes.ElementAt(6)), // Bracket B: 2nd vs 7th
                CompararNotas(filmes.ElementAt(2), filmes.ElementAt(5)), // Bracket C: 3rd vs 6th
                CompararNotas(filmes.ElementAt(3), filmes.ElementAt(4))  // Bracket D: 4th vs 5th
            };
            result.Final = new List<Filme>
            {
                CompararNotas(result.Semifinal.ElementAt(0), result.Semifinal.ElementAt(1)), // Bracket A vs B
                CompararNotas(result.Semifinal.ElementAt(2), result.Semifinal.ElementAt(3)), // Bracket C vs D
            };

            // Para decidir a final, basta dar um Sort Descending na Semifinal.
            result.PrimeiroLugar = CompararNotas(result.Final.ElementAt(0), result.Final.ElementAt(1));
            result.SegundoLugar = CompararNotas(result.Final.ElementAt(0), result.Final.ElementAt(1), false);

            return result;
        }

        /// <summary>
        /// Calcula um torneio de chaves entre os 8 filmes passados, retornando o campeão e vice-campeão respectivamente.
        /// </summary>
        [HttpPost("[action]")]
        public List<Filme> TorneioSimples([FromBody] List<Filme> filmes)
        {
            Torneio result = GerarTorneio(filmes);
            return result.Final;
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

        /// <summary>
        /// Retorna o vencedor da disputa entre os dois filmes, ou retorna o perdedor se retornarVencedor = false.
        /// Se as notas forem iguais, o desempate é feito pela ordem alfabética do título.
        /// </summary>
        public static Filme CompararNotas(Filme filmeA, Filme filmeB, bool retornarVencedor = true)
        {
            // Caso as notas sejam iguais, o primeiro em ordem alfabética vence;
            if (filmeA.Nota == filmeB.Nota)
            {
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) < 0)
                {
                    return retornarVencedor ? filmeA : filmeB;
                }
                return retornarVencedor ? filmeB : filmeA;
            }
            // Senão, comparamos notas normalmente.
            else if (filmeA.Nota > filmeB.Nota)
            {
                return retornarVencedor ? filmeA : filmeB;
            }
            return retornarVencedor ? filmeB : filmeA;
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
            public List<Filme> Quartas { get; set; }
            public List<Filme> Semifinal { get; set; }
            public List<Filme> Final { get; set; }
            public Filme PrimeiroLugar { get; set; }
            public Filme SegundoLugar { get; set; }
        }
    }
}