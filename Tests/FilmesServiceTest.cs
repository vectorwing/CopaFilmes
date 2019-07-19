using Xunit;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Services;
using CopaFilmes.Models;

namespace CopaFilmes.Tests.UnitTests
{

    public class FilmesServiceTest : IClassFixture<FilmesFixture>
    {
        private readonly IFilmesService _FilmesService;

        FilmesFixture fixture;

        public FilmesServiceTest(FilmesFixture fixture)
        {
            _FilmesService = new FilmesService();
            this.fixture = fixture;
        }

        [Fact]
        public void GerarTorneio_FinalFilmeAVsFilmeC_RetornaFilmeAPrimeiroLugar()
        {
            // Quartas: AxH, BxG, CxF, DxE
            // Semifinais: AxB, CxD
            // Finais: AxC
            // Campeão: A
            Filme actual = _FilmesService.GerarTorneio(fixture.Filmes).PrimeiroLugar;

            Assert.Equal(fixture.Filmes.ElementAt(0), actual);
        }
        [Fact]
        public void GerarTorneio_FinalFilmeAVsFilmeC_RetornaFilmeCSegundoLugar()
        {
            // Quartas: AxH, BxG, CxF, DxE
            // Semifinais: AxB, CxD
            // Finais: AxC
            // Vice-campeão: C
            Filme actual = _FilmesService.GerarTorneio(fixture.Filmes).SegundoLugar;

            Assert.Equal(fixture.Filmes.ElementAt(2), actual);
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