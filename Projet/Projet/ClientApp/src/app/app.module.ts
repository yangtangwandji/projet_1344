import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { JoueurComponent } from './joueur/joueur.component';
import { JoueurService } from './joueur.service';
import { JoueurCreateComponent } from './joueur-create/joueur-create.component';
import { JoueurUpdateComponent } from './joueur-update/joueur-update.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    JoueurComponent,
    JoueurCreateComponent,
    JoueurUpdateComponent
    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: JoueurComponent },
      { path: 'create', component: JoueurCreateComponent },
      { path: 'update/:id', component: JoueurUpdateComponent },
    ])
  ],
  providers: [JoueurService],
  bootstrap: [AppComponent]
})
export class AppModule { }
