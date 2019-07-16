import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, FormArray, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {

  filmeForm: FormGroup;
  filmes: Filme[];

  constructor(private http: HttpClient, private fb: FormBuilder, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Filme[]>('https://copadosfilmes.azurewebsites.net/api/filmes').subscribe(
      result => {
        this.filmes = result;
        const formControls = this.filmes.map(control => new FormControl(false));
        this.filmeForm = this.fb.group({
          filmes: this.fb.array(formControls)
        });
      },
      error => console.error(error)
    );
  }

  submit() {
    const selectedFilmes = this.filmeForm.value.filmes
      .map((checked, index) => checked ? this.filmes[index] : null)
      .filter(value => value !== null);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': 'my-auth-token'
      })
    };

    this.http.post(this.baseUrl + 'api/CopaFilmes/TorneioCompleto', selectedFilmes, httpOptions)
      .subscribe(
        hero => console.log(hero)
      )
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}