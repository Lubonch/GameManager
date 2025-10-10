import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface Game {
  id: number;
  name: string;
  year: string;
  publisherId: number;
  publisher?: { name: string };
  consoleId: number;
  console?: { name: string };
  genreId: number;
  genre?: { name: string };
  quantity: number;
  price: number;
}

@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container">
      <header class="header">
        <h1>🎮 Game Manager</h1>
        <nav class="nav">
          <button class="nav-btn active" (click)="currentView = 'list'">📋 Lista de Juegos</button>
          <button class="nav-btn" (click)="currentView = 'add'">➕ Agregar Juego</button>
        </nav>
      </header>

      <main class="main">
        <!-- Lista de Juegos -->
        <div *ngIf="currentView === 'list'" class="game-list">
          <h2>Lista de Juegos ({{ games.length }})</h2>

          <div class="search-bar">
            <input
              type="text"
              [(ngModel)]="searchTerm"
              placeholder="Buscar juegos..."
              class="search-input"
              (input)="filterGames()"
            >
          </div>

          <div class="games-grid">
            <div *ngFor="let game of filteredGames" class="game-card">
              <div class="game-header">
                <h3>{{ game.name }}</h3>
                <span class="game-year">{{ formatDate(game.year) }}</span>
              </div>

              <div class="game-details">
                <div class="detail-item">
                  <span class="label">🏢 Publisher:</span>
                  <span class="value">{{ game.publisher?.name || 'N/A' }}</span>
                </div>
                <div class="detail-item">
                  <span class="label">🎯 Consola:</span>
                  <span class="value">{{ game.console?.name || 'N/A' }}</span>
                </div>
                <div class="detail-item">
                  <span class="label">🎮 Género:</span>
                  <span class="value">{{ game.genre?.name || 'N/A' }}</span>
                </div>
                <div class="detail-item">
                  <span class="label">📦 Cantidad:</span>
                  <span class="value">{{ game.quantity }}</span>
                </div>
                <div class="detail-item">
                  <span class="label">💰 Precio:</span>
                  <span class="value">{{ game.price }}</span>
                </div>
              </div>

              <div class="game-actions">
                <button class="btn btn-edit" (click)="editGame(game)">✏️ Editar</button>
                <button class="btn btn-delete" (click)="deleteGame(game.id)">🗑️ Eliminar</button>
              </div>
            </div>
          </div>

          <div *ngIf="filteredGames.length === 0" class="no-games">
            <p>🎯 No se encontraron juegos</p>
          </div>
        </div>

        <!-- Formulario para Agregar/Editar -->
        <div *ngIf="currentView === 'add'" class="game-form">
          <h2>{{ isEditing ? '✏️ Editar Juego' : '➕ Agregar Nuevo Juego' }}</h2>

          <form (ngSubmit)="onSubmit()" class="form">
            <div class="form-group">
              <label for="name">Nombre del Juego:</label>
              <input
                id="name"
                type="text"
                [(ngModel)]="game.name"
                name="name"
                required
                placeholder="Ingrese el nombre del juego"
                class="form-input"
              >
            </div>

            <div class="form-group">
              <label for="year">Año de Lanzamiento:</label>
              <input
                id="year"
                type="date"
                [(ngModel)]="game.year"
                name="year"
                required
                class="form-input"
              >
            </div>

            <div class="form-row">
              <div class="form-group">
                <label for="publisherId">Publisher ID:</label>
                <input
                  id="publisherId"
                  type="number"
                  [(ngModel)]="game.publisherId"
                  name="publisherId"
                  required
                  placeholder="ID del publisher"
                  class="form-input"
                >
              </div>

              <div class="form-group">
                <label for="consoleId">Console ID:</label>
                <input
                  id="consoleId"
                  type="number"
                  [(ngModel)]="game.consoleId"
                  name="consoleId"
                  required
                  placeholder="ID de la consola"
                  class="form-input"
                >
              </div>

              <div class="form-group">
                <label for="genreId">Genre ID:</label>
                <input
                  id="genreId"
                  type="number"
                  [(ngModel)]="game.genreId"
                  name="genreId"
                  required
                  placeholder="ID del género"
                  class="form-input"
                >
              </div>
            </div>

            <div class="form-row">
              <div class="form-group">
                <label for="quantity">Cantidad:</label>
                <input
                  id="quantity"
                  type="number"
                  [(ngModel)]="game.quantity"
                  name="quantity"
                  required
                  min="0"
                  placeholder="Cantidad disponible"
                  class="form-input"
                >
              </div>

              <div class="form-group">
                <label for="price">Precio:</label>
                <input
                  id="price"
                  type="number"
                  [(ngModel)]="game.price"
                  name="price"
                  required
                  min="0"
                  step="0.01"
                  placeholder="Precio del juego"
                  class="form-input"
                >
              </div>
            </div>

            <div class="form-actions">
              <button type="submit" class="btn btn-primary">
                {{ isEditing ? '💾 Guardar Cambios' : '➕ Agregar Juego' }}
              </button>
              <button type="button" class="btn btn-secondary" (click)="cancelEdit()">
                ❌ Cancelar
              </button>
            </div>
          </form>
        </div>
      </main>
    </div>
  `,
  styles: [`
    .container {
      max-width: 1200px;
      margin: 0 auto;
      padding: 20px;
      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }

    .header {
      background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
      color: white;
      padding: 20px;
      border-radius: 10px;
      margin-bottom: 30px;
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    }

    .header h1 {
      margin: 0 0 15px 0;
      font-size: 2.5em;
      text-align: center;
    }

    .nav {
      display: flex;
      justify-content: center;
      gap: 15px;
    }

    .nav-btn {
      background: rgba(255, 255, 255, 0.2);
      color: white;
      border: 2px solid rgba(255, 255, 255, 0.3);
      padding: 10px 20px;
      border-radius: 25px;
      cursor: pointer;
      font-size: 16px;
      transition: all 0.3s ease;
    }

    .nav-btn:hover, .nav-btn.active {
      background: rgba(255, 255, 255, 0.3);
      border-color: white;
    }

    .main {
      background: white;
      border-radius: 10px;
      padding: 30px;
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    }

    .game-list h2, .game-form h2 {
      color: #333;
      margin-bottom: 20px;
      text-align: center;
    }

    .search-bar {
      margin-bottom: 20px;
      text-align: center;
    }

    .search-input {
      width: 100%;
      max-width: 400px;
      padding: 12px;
      border: 2px solid #ddd;
      border-radius: 25px;
      font-size: 16px;
      transition: border-color 0.3s ease;
    }

    .search-input:focus {
      outline: none;
      border-color: #667eea;
    }

    .games-grid {
      display: grid;
      grid-template-columns: repeat(auto-fill, minmax(350px, 1fr));
      gap: 20px;
      margin-top: 20px;
    }

    .game-card {
      background: #f8f9fa;
      border: 1px solid #e9ecef;
      border-radius: 10px;
      padding: 20px;
      transition: transform 0.3s ease, box-shadow 0.3s ease;
    }

    .game-card:hover {
      transform: translateY(-5px);
      box-shadow: 0 8px 15px rgba(0, 0, 0, 0.1);
    }

    .game-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 15px;
    }

    .game-header h3 {
      margin: 0;
      color: #333;
      font-size: 1.3em;
    }

    .game-year {
      background: #667eea;
      color: white;
      padding: 4px 8px;
      border-radius: 12px;
      font-size: 0.9em;
    }

    .game-details {
      margin-bottom: 15px;
    }

    .detail-item {
      display: flex;
      justify-content: space-between;
      margin-bottom: 8px;
      padding: 5px 0;
      border-bottom: 1px solid #eee;
    }

    .detail-item:last-child {
      border-bottom: none;
    }

    .label {
      font-weight: bold;
      color: #555;
    }

    .value {
      color: #333;
    }

    .game-actions {
      display: flex;
      gap: 10px;
    }

    .btn {
      padding: 8px 16px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      font-size: 14px;
      transition: all 0.3s ease;
    }

    .btn-edit {
      background: #ffc107;
      color: #212529;
    }

    .btn-edit:hover {
      background: #e0a800;
    }

    .btn-delete {
      background: #dc3545;
      color: white;
    }

    .btn-delete:hover {
      background: #c82333;
    }

    .btn-primary {
      background: #28a745;
      color: white;
      padding: 12px 24px;
      font-size: 16px;
    }

    .btn-primary:hover {
      background: #218838;
    }

    .btn-secondary {
      background: #6c757d;
      color: white;
      padding: 12px 24px;
      font-size: 16px;
    }

    .btn-secondary:hover {
      background: #5a6268;
    }

    .no-games {
      text-align: center;
      color: #666;
      font-size: 1.2em;
      margin-top: 50px;
    }

    .game-form {
      max-width: 600px;
      margin: 0 auto;
    }

    .form {
      background: #f8f9fa;
      padding: 30px;
      border-radius: 10px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }

    .form-group {
      margin-bottom: 20px;
    }

    .form-row {
      display: flex;
      gap: 15px;
    }

    .form-row .form-group {
      flex: 1;
    }

    .form-group label {
      display: block;
      margin-bottom: 5px;
      font-weight: bold;
      color: #333;
    }

    .form-input {
      width: 100%;
      padding: 12px;
      border: 2px solid #ddd;
      border-radius: 5px;
      font-size: 16px;
      transition: border-color 0.3s ease;
    }

    .form-input:focus {
      outline: none;
      border-color: #667eea;
    }

    .form-actions {
      display: flex;
      gap: 15px;
      justify-content: center;
      margin-top: 30px;
    }

    @media (max-width: 768px) {
      .container {
        padding: 10px;
      }

      .games-grid {
        grid-template-columns: 1fr;
      }

      .form-row {
        flex-direction: column;
      }

      .nav {
        flex-direction: column;
        align-items: center;
      }
    }
  `]
})
export class GameFormComponent implements OnInit {
  games: Game[] = [];
  filteredGames: Game[] = [];
  searchTerm: string = '';
  currentView: 'list' | 'add' = 'list';
  isEditing: boolean = false;

  game: Game = {
    id: 0,
    name: '',
    year: '',
    publisherId: 0,
    consoleId: 0,
    genreId: 0,
    quantity: 0,
    price: 0
  };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadGames();
  }

  loadGames() {
    this.http.get<Game[]>('http://localhost:5143/api/game').subscribe(
      (result) => {
        this.games = result;
        this.filteredGames = result;
      },
      (error) => {
        console.error('Error loading games:', error);
      }
    );
  }

  filterGames() {
    if (this.searchTerm.trim() === '') {
      this.filteredGames = this.games;
    } else {
      this.filteredGames = this.games.filter(game =>
        game.name.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }
  }

  editGame(game: Game) {
    this.game = { ...game };
    this.isEditing = true;
    this.currentView = 'add';
  }

  deleteGame(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar este juego?')) {
      this.http.delete(`http://localhost:5143/api/game/${id}`).subscribe(
        () => {
          this.loadGames();
        },
        (error) => {
          console.error('Error deleting game:', error);
        }
      );
    }
  }

  onSubmit() {
    if (this.isEditing) {
      this.http.put(`http://localhost:5143/api/game/${this.game.id}`, this.game).subscribe(
        () => {
          this.loadGames();
          this.resetForm();
          this.currentView = 'list';
        },
        (error) => {
          console.error('Error updating game:', error);
        }
      );
    } else {
      this.http.post('http://localhost:5143/api/game', this.game).subscribe(
        () => {
          this.loadGames();
          this.resetForm();
          this.currentView = 'list';
        },
        (error) => {
          console.error('Error adding game:', error);
        }
      );
    }
  }

  cancelEdit() {
    this.resetForm();
    this.currentView = 'list';
  }

  resetForm() {
    this.game = {
      id: 0,
      name: '',
      year: '',
      publisherId: 0,
      consoleId: 0,
      genreId: 0,
      quantity: 0,
      price: 0
    };
    this.isEditing = false;
  }

  formatDate(dateString: string): string {
    if (!dateString) return '';
    const date = new Date(dateString);
    return date.getFullYear().toString();
  }
}
