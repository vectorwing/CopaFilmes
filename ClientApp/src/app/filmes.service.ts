import { Injectable } from '@angular/core';

@Injectable() 
export class FilmesService {
  filmes: Filme[];
  resultado;
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}