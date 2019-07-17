import { Component } from '@angular/core';
import { FilmesService } from '../filmes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {
  resultado: any;

  constructor(private router: Router, private filmesService: FilmesService) {
    this.resultado = filmesService.resultado;
    if (!this.resultado) {
      this.router.navigate(['']);
    }
    console.log(this.resultado);
  }

}
