import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-copa-filmes',
  templateUrl: './copa-filmes.component.html'
})
export class CopaFilmesComponent {
  public filmes: Filme[];

  constructor(http: HttpClient) {
    http.get<Filme[]>('https://copadosfilmes.azurewebsites.net/api/filmes').subscribe(result => {
      this.filmes = result;
    }, error => console.error(error));
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}