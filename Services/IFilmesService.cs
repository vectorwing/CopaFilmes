using CopaFilmes.Models;

namespace CopaFilmes.Services
{
    public interface IFilmesService
    {
        Filme CompararNotas(Filme filmeA, Filme filmeB, bool retornarVencedor = true);
    }
}