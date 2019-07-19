using System.Collections.Generic;
using CopaFilmes.Models;

namespace CopaFilmes.Services
{
    public interface IFilmesService
    {
        Filme CompararFilmes(Filme filmeA, Filme filmeB, bool retornarVencedor = true);
        
        Torneio GerarTorneio(List<Filme> filmes);
    }
}