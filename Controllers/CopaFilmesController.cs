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

        [HttpPost("[action]")]
        public List<Filme> TorneioSimples([FromBody] List<Filme> filmes)
        {
            Torneio result = _FilmesService.GerarTorneio(filmes);
            return result.Final;
        }

        [HttpPost("[action]")]
        public Torneio TorneioCompleto([FromBody] List<Filme> filmes)
        {
            Torneio result = _FilmesService.GerarTorneio(filmes);
            return result;
        }
    }
}