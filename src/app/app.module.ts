import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GameListComponent } from './components/game-list/game-list.component';
import { GameFormComponent } from './components/game-form/game-form.component';
import { PublisherListComponent } from './components/publisher-list/publisher-list.component';
import { ConsoleListComponent } from './components/console-list/console-list.component';
import { GenreListComponent } from './components/genre-list/genre-list.component';

@NgModule({
  declarations: [
    AppComponent,
    GameListComponent,
    GameFormComponent,
    PublisherListComponent,
    ConsoleListComponent,
    GenreListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
