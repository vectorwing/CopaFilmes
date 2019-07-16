import { Component } from '@angular/core';
import { FilmesService } from '../filmes.service';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {
  resultado;

  constructor(private filmesService: FilmesService) {
    this.resultado = filmesService.resultado;
    console.log(this.resultado);
  }

}
