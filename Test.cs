using Xunit;
using CopaFilmes.Controllers;

namespace CopaFilmes.Tests.UnitTests
{

    public class Test
    {
        [Fact]
        public void PassingCompararNotasTest()
        {
            CopaFilmesController.Filme filmeA = new CopaFilmesController.Filme()
            {
                Id = "tt3606756",
                Titulo = "Os Incríveis 2",
                Ano = 2018,
                Nota = 8.5
            };
            CopaFilmesController.Filme filmeB = new CopaFilmesController.Filme()
            {
                Id = "tt4881806",
                Titulo = "Jurassic World: Reino Ameaçado",
                Ano = 2018,
                Nota = 6.7
            };
            Assert.Equal(filmeA, CopaFilmesController.CompararNotas(filmeA, filmeB));
        }
    }

}