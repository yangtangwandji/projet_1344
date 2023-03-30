import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JoueurService } from '../joueur.service';
import { Joueur } from '../joueur/joueur.component';

@Component({
  selector: 'app-joueur-create',
  templateUrl: './joueur-create.component.html',
  styleUrls: []
})
export class JoueurCreateComponent implements OnInit {


  private joueurNew: JoueurNew = new JoueurNew();
  public messageError: any;
  public createJoueurForm: FormGroup | any;
  public submitted = false;
  public joueur: Joueur | undefined;


  constructor(private httpClient: HttpClient, private jService: JoueurService, private fb: FormBuilder, private router: Router) {
    this.createForm();
  }


  ngOnInit(): void {
    /*this.jService.verifAutorisation("/");*/
    /*this.getJoueur()*/
  }

  createForm() {
    this.createJoueurForm = this.fb.group({
      nom: ['', Validators.compose([Validators.required])],
      prenom: ['', Validators.compose([Validators.required])],
      age: ['', Validators.compose([Validators.required, Validators.min(0)])],
      equipe: ['', Validators.compose([Validators.required])],
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.createJoueurForm.invalid) {
      return;
    }

    let value = this.createJoueurForm.value;
    this.joueurNew.nom = value.nom;
    this.joueurNew.prenom = value.prenom;
    this.joueurNew.age = value.age.toString();
    this.joueurNew.equipe = value.equipe;
    console.log(this.joueurNew);
    this.createJoueur();
  }

  get f() { return this.createJoueurForm.controls; }

  createJoueur() {
    this.httpClient.post(`https://localhost:7071/Joueur`,this.joueurNew)
      .subscribe(
        () => {
          this.router.navigate(['/']);
        }, error => {
          console.log(error);
        }
      )
  }
}

export class JoueurNew {
  id: number | any;
  nom: string | any;
  prenom: string | any;
  age: string | any;
  equipe: string | any;
}
