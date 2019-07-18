using System.Collections.Generic;

namespace CopaFilmes.Models
{
    public class Torneio
    {
        public List<Filme> Quartas { get; set; }
        public List<Filme> Semifinal { get; set; }
        public List<Filme> Final { get; set; }
        public Filme PrimeiroLugar { get; set; }
        public Filme SegundoLugar { get; set; }
    }
}