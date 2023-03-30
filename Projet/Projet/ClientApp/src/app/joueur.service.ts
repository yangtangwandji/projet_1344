import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class JoueurService {

  private objectInJson: any = sessionStorage.getItem("user");
  private user = JSON.parse(this.objectInJson);

  constructor(private router: Router, private http: HttpClient) { }

  //httpOptions = {
  //  headers: new HttpHeaders({
  //    'Authorization': 'Bearer ' + this.user.token
  //  })
  //};

  public verifAutorisation(redirectToRoute: string) {

    this.objectInJson = sessionStorage.getItem("user");
    this.user = JSON.parse(this.objectInJson);

    const decode = JSON.parse(atob(this.user.token.split('.')[1]));
    let t2 = decode.exp + "000";
    console.log(+t2);
    console.log(+new Date());
    if (+t2 < (+new Date())) {
      console.log(decode.exp + "000", +new Date());
      sessionStorage.removeItem("user");
      this.router.navigate(['/']);
    }
  }

  //public delete(id: string) {
  //  this.http.delete(`https://localhost:7071/joueur/${id}`, this.httpOptions).subscribe(
  //    result => {
  //      this.router.navigate(['/joueur']);
  //    }, error => {
  //      console.log(error);
  //    }
  //  )
  //}
}
