using System.Collections.Generic;
using CopaFilmes.Models;

namespace CopaFilmes.Services
{
    public interface IFilmesService
    {
        DisputaFilmes DisputarFilmes(Filme filmeA, Filme filmeB);
        
        Torneio GerarTorneio(List<Filme> filmes);
    }
}