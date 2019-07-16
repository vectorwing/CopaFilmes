import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, FormControl, ValidatorFn } from '@angular/forms';
import { Router } from '@angular/router';
import { FilmesService } from '../filmes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  filmeForm: FormGroup;
  filmes: Filme[];

  constructor(private filmesService: FilmesService, private router: Router, private fb: FormBuilder) {
    filmesService.getFilmes().subscribe(
      result => {
        this.filmes = result;
        const formControls = this.filmes.map(control => new FormControl(false));
        this.filmeForm = this.fb.group({
          filmes: this.fb.array(formControls, exactSelectedCheckboxes())
        });
      },
      error => console.error(error)
    );
  }

  submit() {
    const selectedFilmes = this.filmeForm.value.filmes
      .map((checked, index) => checked ? this.filmes[index] : null)
      .filter(value => value !== null);

    this.filmesService.postSelectedFilmes(selectedFilmes).subscribe(
      result => {
        this.filmesService.resultado = result;
        this.router.navigate(['results']);
      }
    )
  }
}

function exactSelectedCheckboxes(total = 8) {
  const validator: ValidatorFn = (formArray: FormArray) => {
    return countSelected(formArray) == total ? null : { required: true };
  };

  return validator;
}

function countSelected(formArray : FormArray) {
  const totalSelected = formArray.controls
      .map(control => control.value)
      .reduce((prev, next) => next ? prev + next : prev, 0);
  return totalSelected;
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}