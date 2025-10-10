import { Component, OnInit } from '@angular/core';
import { Genre } from '../../models/game.models';

@Component({
  selector: 'app-genre-list',
  templateUrl: './genre-list.component.html',
  styleUrls: ['./genre-list.component.css'],
  standalone: false
})
export class GenreListComponent implements OnInit {
  genres: Genre[] = [];
  loading = false;
  error: string | null = null;

  ngOnInit(): void {
    this.loadGenres();
  }

  loadGenres(): void {
    this.loading = true;
    // Mock data
    this.genres = [
      { id: 1, name: 'Action' },
      { id: 2, name: 'Adventure' },
      { id: 3, name: 'RPG' },
      { id: 4, name: 'Strategy' },
      { id: 5, name: 'Sports' },
      { id: 6, name: 'Racing' }
    ];
    this.loading = false;
  }

  onDeleteGenre(id: number): void {
    if (confirm('Are you sure you want to delete this genre?')) {
      this.genres = this.genres.filter(g => g.id !== id);
    }
  }
}
