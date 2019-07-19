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
        public void GerarTorneio_FinalFilmeAvsFilmeC_RetornaFilmeAVencedorFilmeCPerdedor()
        {
            // Quartas: AxH, BxG, CxF, DxE
            // Semifinais: AxB, CxD
            // Finais: AxC
            // Campeão: A
            DisputaFilmes expected = new DisputaFilmes();
            expected.Vencedor = fixture.Filmes.Find(x => x.Titulo == "A");
            expected.Perdedor = fixture.Filmes.Find(x => x.Titulo == "C");
            DisputaFilmes actual = _FilmesService.GerarTorneio(fixture.Filmes).Resultado;

            Assert.Equal(expected.Vencedor, actual.Vencedor);
        }

        [Fact]
        public void DisputarFilmes_FilmeANotaMaior_RetornaFilmeA()
        {
            // Arrange
            Filme filmeA = new Filme()
            { Nota = 2 };
            Filme filmeB = new Filme()
            { Nota = 1 };

            // Act
            DisputaFilmes expected = new DisputaFilmes();
            expected.Vencedor = filmeA;
            expected.Perdedor = filmeB;
            DisputaFilmes actual = _FilmesService.DisputarFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(expected.Vencedor, actual.Vencedor);
        }
        [Fact]
        public void DisputarFilmes_FilmeBNotaMaior_RetornaFilmeB()
        {
            // Arrange
            Filme filmeA = new Filme()
            { Nota = 1 };
            Filme filmeB = new Filme()
            { Nota = 2 };

            // Act
            DisputaFilmes expected = new DisputaFilmes();
            expected.Vencedor = filmeB;
            expected.Perdedor = filmeA;
            DisputaFilmes actual = _FilmesService.DisputarFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(expected.Vencedor, actual.Vencedor);
        }
        [Fact]
        public void DisputarFilmes_NotasIguaisFilmeATituloAntes_RetornaFilmeA()
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
            DisputaFilmes expected = new DisputaFilmes();
            expected.Vencedor = filmeA;
            expected.Perdedor = filmeB;
            DisputaFilmes actual = _FilmesService.DisputarFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(expected.Vencedor, actual.Vencedor);
        }
        [Fact]
        public void DisputarFilmes_NotasIguaisFilmeBTituloAntes_RetornaFilmeB()
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
            DisputaFilmes expected = new DisputaFilmes();
            expected.Vencedor = filmeB;
            expected.Perdedor = filmeA;
            DisputaFilmes actual = _FilmesService.DisputarFilmes(filmeA, filmeB);

            // Assert
            Assert.Equal(expected.Vencedor, actual.Vencedor);
        }
    }

}