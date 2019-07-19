using CopaFilmes.Models;

namespace CopaFilmes.Services
{
    public class FilmesService : IFilmesService
    {
        public Filme CompararNotas(Filme filmeA, Filme filmeB, bool retornarVencedor = true)
        {
            // Caso as notas sejam iguais, o primeiro em ordem alfabética vence;
            if (filmeA.Nota == filmeB.Nota)
            {
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) < 0)
                {
                    return retornarVencedor ? filmeA : filmeB;
                }
                return retornarVencedor ? filmeB : filmeA;
            }
            // Senão, comparamos notas normalmente.
            else if (filmeA.Nota > filmeB.Nota)
            {
                return retornarVencedor ? filmeA : filmeB;
            }
            return retornarVencedor ? filmeB : filmeA;
        }
    }
}