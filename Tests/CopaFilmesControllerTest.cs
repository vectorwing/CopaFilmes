using Xunit;
using CopaFilmes.Controllers;

namespace CopaFilmes.Tests.UnitTests
{

    public class CopaFilmesControllerTest
    {
        [Fact]
        public void CompararNotas_FilmeANotaMaior_RetornaFilmeA()
        {
            // Arrange
            CopaFilmesController.Filme filmeA = new CopaFilmesController.Filme()
            { Nota = 2 };
            CopaFilmesController.Filme filmeB = new CopaFilmesController.Filme()
            { Nota = 1 };

            // Act
            CopaFilmesController.Filme actual = CopaFilmesController.CompararNotas(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeA, actual);
        }
        [Fact]
        public void CompararNotas_FilmeBNotaMaior_RetornaFilmeB()
        {
            // Arrange
            CopaFilmesController.Filme filmeA = new CopaFilmesController.Filme()
            { Nota = 1 };
            CopaFilmesController.Filme filmeB = new CopaFilmesController.Filme()
            { Nota = 2 };

            // Act
            CopaFilmesController.Filme actual = CopaFilmesController.CompararNotas(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeB, actual);
        }
        [Fact]
        public void CompararNotas_NotasIguaisFilmeATituloAntes_RetornaFilmeA()
        {
            // Arrange
            CopaFilmesController.Filme filmeA = new CopaFilmesController.Filme()
            {
                Titulo = "A",
                Nota = 1
            };
            CopaFilmesController.Filme filmeB = new CopaFilmesController.Filme()
            {
                Titulo = "B",
                Nota = 1
            };

            // Act
            CopaFilmesController.Filme actual = CopaFilmesController.CompararNotas(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeA, actual);
        }
        [Fact]
        public void CompararNotas_NotasIguaisFilmeBTituloAntes_RetornaFilmeB()
        {
            // Arrange
            CopaFilmesController.Filme filmeA = new CopaFilmesController.Filme()
            {
                Titulo = "B",
                Nota = 1
            };
            CopaFilmesController.Filme filmeB = new CopaFilmesController.Filme()
            {
                Titulo = "A",
                Nota = 1
            };

            // Act
            CopaFilmesController.Filme actual = CopaFilmesController.CompararNotas(filmeA, filmeB);

            // Assert
            Assert.Equal(filmeB, actual);
        }
    }

}