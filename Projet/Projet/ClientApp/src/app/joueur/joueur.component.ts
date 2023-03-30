import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JoueurService } from '../joueur.service';

@Component({
  selector: 'app-joueur',
  templateUrl: './joueur.component.html',
  styleUrls: []
})
export class JoueurComponent implements OnInit {

  private httpClient: HttpClient;
  public joueurs: Joueur[] | undefined;
  

  constructor(private router: Router,http: HttpClient, private jService: JoueurService) {
    this.httpClient = http;

  }


  ngOnInit(): void {

    this.getJoueur();
  }

  getJoueur() {
    /*this.jService.verifAutorisation("/");*/


    this.httpClient.get<Joueur[]>(`https://localhost:7071/Joueur`)
      .subscribe(
        result => {
          this.joueurs = result;
          // sessionStorage.setItem("token", result.token);
        }, error => {
          console.log(error);
        }
      )
  }

  public delete(id: number) {
    this.httpClient.delete<string>(`https://localhost:7071/joueur/${id}`)
      .subscribe(
        () => {
          this.getJoueur();
      }, error => {
        console.log(error);
      }
    )
  }

}

export interface Joueur {
  id:number
  nom: string;
  prenom: string;
  age: string;
  equipe: string;

}
