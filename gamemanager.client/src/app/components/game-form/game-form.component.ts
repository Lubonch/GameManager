import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface Game {
  id: number;
  name: string;
  year: string;
  publisherId: number;
  consoleId: number;
  genreId: number;
  quantity: number;
  price: number;
}

@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h2>Games</h2>
    <ul>
      <li *ngFor="let game of games">{{ game.name }} - {{ game.year }}</li>
    </ul>
    <form (ngSubmit)="onSubmit()">
      <input [(ngModel)]="game.name" name="name" placeholder="Name" required />
      <input [(ngModel)]="game.year" name="year" type="date" required />
      <input [(ngModel)]="game.publisherId" name="publisherId" type="number" placeholder="Publisher ID" required />
      <input [(ngModel)]="game.consoleId" name="consoleId" type="number" placeholder="Console ID" required />
      <input [(ngModel)]="game.genreId" name="genreId" type="number" placeholder="Genre ID" required />
      <input [(ngModel)]="game.quantity" name="quantity" type="number" placeholder="Quantity" required />
      <input [(ngModel)]="game.price" name="price" type="number" step="0.01" placeholder="Price" required />
      <button type="submit">Save</button>
    </form>
  `,
})
export class GameFormComponent implements OnInit {
  games: Game[] = [];
  game: Game = { id: 0, name: '', year: '', publisherId: 0, consoleId: 0, genreId: 0, quantity: 0, price: 0 };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadGames();
  }

  loadGames() {
    this.http.get<Game[]>('https://localhost:5001/api/game').subscribe(
      (result) => {
        this.games = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  onSubmit() {
    this.http.post('https://localhost:5001/api/game', this.game).subscribe(
      () => {
        this.loadGames();
        this.game = { id: 0, name: '', year: '', publisherId: 0, consoleId: 0, genreId: 0, quantity: 0, price: 0 };
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
