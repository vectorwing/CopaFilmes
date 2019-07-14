import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-copa-filmes',
  templateUrl: './copa-filmes.component.html'
})
export class CopaFilmesComponent {
  
  filmForm: FormGroup;
  filmes;

  constructor(http: HttpClient, private fb: FormBuilder) {
    http.get('https://copadosfilmes.azurewebsites.net/api/filmes').subscribe(
      result => this.filmes = result,
      error => console.error(error)
    );

    this.filmForm = this.fb.group({
      filmes: new FormArray([])
    });

    console.log(this.filmes);
    //this.addCheckboxes();
  }
  
  private addCheckboxes() {
    this.filmes.map((o, i) => {
      const control = new FormControl(i === 0); // if first item set to true, else false
      (this.filmForm.controls.filmes as FormArray).push(control);
    });
  }
}

// interface Filme {
//   id: string;
//   titulo: string;
//   ano: number;
//   nota: number;
// }