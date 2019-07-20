import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable() 
export class FilmesService {
  filmes: Filme[];
  resultado: any;
  lambda3URL = 'https://copadosfilmes.azurewebsites.net/api/filmes';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}

  public getFilmes() {
    return this.http.get<Filme[]>(this.lambda3URL);
  }

  public postSelectedFilmes(filmes: Filme[]) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'my-auth-token'
      })
    };
    return this.http.post(this.baseUrl + 'api/CopaFilmes/TorneioSimples', filmes, httpOptions);
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}