import { Component, OnInit } from '@angular/core';
import { GameService } from '../../services/game.service';
import { Game } from '../../models/game.models';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.css'],
  standalone: false
})
export class GameListComponent implements OnInit {
  games: Game[] = [];
  loading = false;
  error: string | null = null;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.loadGames();
  }

  loadGames(): void {
    this.loading = true;
    this.error = null;
    this.gameService.getAllGames().subscribe({
      next: (games) => {
        this.games = games;
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Error loading games: ' + error.message;
        this.loading = false;
      }
    });
  }

  onDeleteGame(id: number): void {
    if (confirm('Are you sure you want to delete this game?')) {
      this.gameService.deleteGameById(id).subscribe({
        next: () => {
          this.loadGames(); // Reload the list
        },
        error: (error) => {
          this.error = 'Error deleting game: ' + error.message;
        }
      });
    }
  }
}
