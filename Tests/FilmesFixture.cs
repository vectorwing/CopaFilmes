using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Models;

namespace CopaFilmes.Tests.UnitTests
{
    public class FilmesFixture
    {
        public List<Filme> Filmes {get; set;}

        public FilmesFixture()
        {
            Filmes = new List<Filme>()
            {
                new Filme() {Titulo = "B", Nota = 6},
                new Filme() {Titulo = "G", Nota = 1},
                new Filme() {Titulo = "E", Nota = 3},
                new Filme() {Titulo = "H", Nota = 0},
                new Filme() {Titulo = "F", Nota = 2},
                new Filme() {Titulo = "C", Nota = 5},
                new Filme() {Titulo = "D", Nota = 4},
                new Filme() {Titulo = "A", Nota = 7},
            };
        }
    }
}