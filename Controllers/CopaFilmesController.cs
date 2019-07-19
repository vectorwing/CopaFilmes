using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Models;
using CopaFilmes.Services;

namespace CopaFilmes.Controllers
{
    [Route("api/[controller]")]
    public class CopaFilmesController : Controller
    {
        private readonly IFilmesService _FilmesService;

        public CopaFilmesController(IFilmesService FilmesService)
        {
            _FilmesService = FilmesService;
        }

        public Torneio GerarTorneio(List<Filme> filmes)
        {
            Torneio result = new Torneio();

            filmes.Sort((x,y) => x.Titulo.CompareTo(y.Titulo));
            result.Quartas = filmes;

            result.Semifinal = new List<Filme>
            {
                _FilmesService.CompararNotas(filmes.ElementAt(0), filmes.ElementAt(7)), // Bracket A: 1st vs 8th
                _FilmesService.CompararNotas(filmes.ElementAt(1), filmes.ElementAt(6)), // Bracket B: 2nd vs 7th
                _FilmesService.CompararNotas(filmes.ElementAt(2), filmes.ElementAt(5)), // Bracket C: 3rd vs 6th
                _FilmesService.CompararNotas(filmes.ElementAt(3), filmes.ElementAt(4))  // Bracket D: 4th vs 5th
            };
            result.Final = new List<Filme>
            {
                _FilmesService.CompararNotas(result.Semifinal.ElementAt(0), result.Semifinal.ElementAt(1)), // Bracket A vs B
                _FilmesService.CompararNotas(result.Semifinal.ElementAt(2), result.Semifinal.ElementAt(3)), // Bracket C vs D
            };

            // Para decidir a final, basta dar um Sort Descending na Semifinal.
            result.PrimeiroLugar = _FilmesService.CompararNotas(result.Final.ElementAt(0), result.Final.ElementAt(1));
            result.SegundoLugar = _FilmesService.CompararNotas(result.Final.ElementAt(0), result.Final.ElementAt(1), false);

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
    }
}