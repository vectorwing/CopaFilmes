using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Models;

namespace CopaFilmes.Services
{
    public class FilmesService : IFilmesService
    {
        /// <summary>
        /// Compara a nota entre dois filmes, e retorna um objeto com o filme vencedor e o filme perdedor da disputa.
        /// Em caso de empate, o título é comparado; o primeiro em ordem alfabética vence.
        /// </summary>
        public DisputaFilmes DisputarFilmes(Filme filmeA, Filme filmeB)
        {
            DisputaFilmes disputa = new DisputaFilmes();
            if (filmeA.Nota == filmeB.Nota)
            {
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) < 0)
                {
                    disputa.Vencedor = filmeA;
                    disputa.Perdedor = filmeB;
                } else {
                    disputa.Vencedor = filmeB;
                    disputa.Perdedor = filmeA;
                }
            }
            else if (filmeA.Nota > filmeB.Nota)
            {
                disputa.Vencedor = filmeA;
                disputa.Perdedor = filmeB;
            } else {
                disputa.Vencedor = filmeB;
                disputa.Perdedor = filmeA;
            }

            return disputa;
        }

        /// <summary>
        /// Cria e retorna um Torneio entre 8 filmes listados, listando os vencedores de cada rodada.
        /// </summary>
        public Torneio GerarTorneio(List<Filme> filmes)
        {
            Torneio torneio = new Torneio();

            filmes.Sort((x,y) => x.Titulo.CompareTo(y.Titulo));
            torneio.Quartas = filmes;

            torneio.Semifinal = new List<Filme>
            {
                DisputarFilmes(filmes.ElementAt(0), filmes.ElementAt(7)).Vencedor, // Bracket A: 1st vs 8th
                DisputarFilmes(filmes.ElementAt(1), filmes.ElementAt(6)).Vencedor, // Bracket B: 2nd vs 7th
                DisputarFilmes(filmes.ElementAt(2), filmes.ElementAt(5)).Vencedor, // Bracket C: 3rd vs 6th
                DisputarFilmes(filmes.ElementAt(3), filmes.ElementAt(4)).Vencedor  // Bracket D: 4th vs 5th
            };
            torneio.Final = new List<Filme>
            {
                DisputarFilmes(torneio.Semifinal.ElementAt(0), torneio.Semifinal.ElementAt(1)).Vencedor, // Bracket A vs B
                DisputarFilmes(torneio.Semifinal.ElementAt(2), torneio.Semifinal.ElementAt(3)).Vencedor, // Bracket C vs D
            };

            torneio.Resultado = DisputarFilmes(torneio.Final.ElementAt(0), torneio.Final.ElementAt(1));

            return torneio;
        }
    }
}