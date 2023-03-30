import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JoueurNew } from '../joueur-create/joueur-create.component';
import { JoueurService } from '../joueur.service';
import { Joueur } from '../joueur/joueur.component';

@Component({
  selector: 'app-joueur-update',
  templateUrl: './joueur-update.component.html',
  styleUrls: ['./joueur-update.component.css']
})
export class JoueurUpdateComponent implements OnInit {


  private joueurUpdate: JoueurNew = new JoueurNew();
  public messageError: any;
  public createJoueurForm: FormGroup | any;
  public submitted = false;
  public joueur: Joueur | undefined;


  constructor(private httpClient: HttpClient, private jService: JoueurService,
    private fb: FormBuilder, private router: Router, private activedRoute: ActivatedRoute) {
    
  }


  ngOnInit(): void {
    /*this.jService.verifAutorisation("login");*/
    this.getJoueur();
  }

  createForm() {
    this.createJoueurForm = this.fb.group({
      nom: ['', Validators.compose([Validators.required])],
      prenom: ['', Validators.compose([Validators.required])],
      age: ['', Validators.compose([Validators.required])],
      equipe: ['', Validators.compose([Validators.required])],
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.createJoueurForm.invalid) {
      return;
    }

    let value = this.createJoueurForm.value;
    this.joueurUpdate.id = value.id;
    this.joueurUpdate.nom = value.nom;
    this.joueurUpdate.prenom = value.prenom;
    this.joueurUpdate.age = value.age.toString();
    this.joueurUpdate.equipe = value.equipe;
    console.log(this.joueurUpdate);
    this.updateJoueur(value.id);
  }

  get f() { return this.createJoueurForm.controls; }

  updateJoueur(id:number) {
    this.httpClient.put(`https://localhost:7071/Joueur/${id}`, this.joueurUpdate)
      .subscribe(
        () => {
          this.router.navigate(['/']);
        }, error => {
          console.log(error);
        }
      )
  }

  getJoueur() {
    /*this.jService.verifAutorisation("");*/

    let id = this.activedRoute.snapshot.paramMap.get('id');
    this.httpClient.get<Joueur>(`https://localhost:7071/Joueur/${id}`)
      .subscribe(
        result => {
          this.joueur = result;
          console.table(result);
          this.createJoueurForm = this.fb.group({
            id: [result.id, Validators.compose([Validators.required])],
            nom: [result.nom, Validators.compose([Validators.required])],
            prenom: [result.prenom, Validators.compose([Validators.required])],
            age: [result.age, Validators.compose([Validators.required, Validators.min(0)])],
            equipe: [result.equipe, Validators.compose([Validators.required])],
          })
          // sessionStorage.setItem("token", result.token);
        }, error => {
          console.log(error);
        }
      )
  }
}
