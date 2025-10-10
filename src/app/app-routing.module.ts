import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameListComponent } from './components/game-list/game-list.component';
import { GameFormComponent } from './components/game-form/game-form.component';
import { PublisherListComponent } from './components/publisher-list/publisher-list.component';
import { ConsoleListComponent } from './components/console-list/console-list.component';
import { GenreListComponent } from './components/genre-list/genre-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/games', pathMatch: 'full' },
  { path: 'games', component: GameListComponent },
  { path: 'games/new', component: GameFormComponent },
  { path: 'games/edit/:id', component: GameFormComponent },
  { path: 'publishers', component: PublisherListComponent },
  { path: 'publishers/new', component: PublisherListComponent }, // Placeholder - would need form component
  { path: 'publishers/edit/:id', component: PublisherListComponent }, // Placeholder - would need form component
  { path: 'consoles', component: ConsoleListComponent },
  { path: 'consoles/new', component: ConsoleListComponent }, // Placeholder - would need form component
  { path: 'consoles/edit/:id', component: ConsoleListComponent }, // Placeholder - would need form component
  { path: 'genres', component: GenreListComponent },
  { path: 'genres/new', component: GenreListComponent }, // Placeholder - would need form component
  { path: 'genres/edit/:id', component: GenreListComponent }, // Placeholder - would need form component
  { path: '**', redirectTo: '/games' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
