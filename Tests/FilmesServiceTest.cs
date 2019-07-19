using Xunit;
using CopaFilmes.Services;
using CopaFilmes.Models;

namespace CopaFilmes.Tests.UnitTests
{

    public class FilmesServiceTest
    {
        private readonly IFilmesService _FilmesService;

        public FilmesServiceTest(IFilmesService FilmesService)
        {
            _FilmesService = FilmesService;
        }

        [Fact]
        public void CompararNotas_FilmeANotaMaior_RetornaFilmeA()
        {
            // Arrange
            Filme filmeA = new Filme()
            { Nota = 2 };
            Filme filmeB = new Filme()
            { Nota = 1 };

            // Act
            Filme actual = _FilmesService.CompararFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeA, actual);
        }
        [Fact]
        public void CompararNotas_FilmeBNotaMaior_RetornaFilmeB()
        {
            // Arrange
            Filme filmeA = new Filme()
            { Nota = 1 };
            Filme filmeB = new Filme()
            { Nota = 2 };

            // Act
            Filme actual = _FilmesService.CompararFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeB, actual);
        }
        [Fact]
        public void CompararNotas_NotasIguaisFilmeATituloAntes_RetornaFilmeA()
        {
            // Arrange
            Filme filmeA = new Filme()
            {
                Titulo = "A",
                Nota = 1
            };
            Filme filmeB = new Filme()
            {
                Titulo = "B",
                Nota = 1
            };

            // Act
            Filme actual = _FilmesService.CompararFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeA, actual);
        }
        [Fact]
        public void CompararNotas_NotasIguaisFilmeBTituloAntes_RetornaFilmeB()
        {
            // Arrange
            Filme filmeA = new Filme()
            {
                Titulo = "B",
                Nota = 1
            };
            Filme filmeB = new Filme()
            {
                Titulo = "A",
                Nota = 1
            };

            // Act
            Filme actual = _FilmesService.CompararFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeB, actual);
        }
    }

}