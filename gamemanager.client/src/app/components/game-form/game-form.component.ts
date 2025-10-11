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

interface Publisher {
  id: number;
  name: string;
}

interface Console {
  id: number;
  name: string;
}

interface Genre {
  id: number;
  name: string;
}

@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container">
      <header class="header">
        <h1>🎮 Game Manager</h1>
        <div class="user-selector">
          <label for="currentUser">Usuario actual:</label>
          <select
            id="currentUser"
            [(ngModel)]="currentUserId"
            name="currentUser"
            class="form-input"
          >
            <option value="0">Seleccione usuario</option>
            <option *ngFor="let person of people" [value]="person.id">
              {{ person.name }}
            </option>
          </select>
        </div>
        <nav class="nav">
          <button class="nav-btn active" (click)="currentView = 'list'">📋 Lista de Juegos</button>
          <button class="nav-btn" (click)="currentView = 'add'">➕ Agregar Juego</button>
          <button class="nav-btn" (click)="currentView = 'masters'">⚙️ Maestros</button>
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
                <label for="publisherId">Publisher:</label>
                <select
                  id="publisherId"
                  [(ngModel)]="game.publisherId"
                  name="publisherId"
                  required
                  class="form-input"
                >
                  <option value="">Seleccione un Publisher</option>
                  <option *ngFor="let publisher of publishers" [value]="publisher.id">
                    {{ publisher.name }}
                  </option>
                </select>
              </div>

              <div class="form-group">
                <label for="consoleId">Consola:</label>
                <select
                  id="consoleId"
                  [(ngModel)]="game.consoleId"
                  name="consoleId"
                  required
                  class="form-input"
                >
                  <option value="">Seleccione una Consola</option>
                  <option *ngFor="let console of consoles" [value]="console.id">
                    {{ console.name }}
                  </option>
                </select>
              </div>

              <div class="form-group">
                <label for="genreId">Género:</label>
                <select
                  id="genreId"
                  [(ngModel)]="game.genreId"
                  name="genreId"
                  required
                  class="form-input"
                >
                  <option value="">Seleccione un Género</option>
                  <option *ngFor="let genre of genres" [value]="genre.id">
                    {{ genre.name }}
                  </option>
                </select>
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

        <!-- Menú de Maestros -->
        <div *ngIf="currentView === 'masters'" class="masters-menu">
          <h2>⚙️ Gestión de Maestros</h2>
          <div class="masters-grid">
            <div class="master-card" (click)="currentView = 'publishers'">
              <div class="master-icon">🏢</div>
              <h3>Publishers</h3>
              <p>Gestionar compañías desarrolladoras</p>
              <span class="master-count">{{ publishers.length }} registrados</span>
            </div>

            <div class="master-card" (click)="currentView = 'consoles'">
              <div class="master-icon">🎮</div>
              <h3>Consolas</h3>
              <p>Gestionar plataformas de juegos</p>
              <span class="master-count">{{ consoles.length }} registradas</span>
            </div>

            <div class="master-card" (click)="currentView = 'genres'">
              <div class="master-icon">🎯</div>
              <h3>Géneros</h3>
              <p>Gestionar categorías de juegos</p>
              <span class="master-count">{{ genres.length }} registros</span>
            </div>

            <div class="master-card" (click)="currentView = 'people'">
              <div class="master-icon">👥</div>
              <h3>Personas</h3>
              <p>Gestionar usuarios del sistema</p>
              <span class="master-count">{{ people.length }} registradas</span>
            </div>
          </div>

          <div class="back-button">
            <button class="btn btn-secondary" (click)="currentView = 'list'">⬅️ Volver</button>
          </div>
        </div>

        <!-- Gestión de Publishers -->
        <div *ngIf="currentView === 'publishers'" class="master-management">
          <h2>🏢 Gestión de Publishers</h2>
          <div class="master-actions">
            <button class="btn btn-primary" (click)="showPublisherForm = true; editingPublisher = null; newPublisher = { id: 0, name: '' }">➕ Agregar Publisher</button>
            <button class="btn btn-secondary" (click)="currentView = 'masters'">⬅️ Volver</button>
          </div>

          <div class="master-list">
            <div *ngFor="let publisher of publishers" class="master-item">
              <span>{{ publisher.name }}</span>
              <div class="item-actions">
                <button class="btn btn-edit" (click)="editPublisher(publisher)">✏️</button>
                <button class="btn btn-delete" (click)="deletePublisher(publisher.id)">🗑️</button>
              </div>
            </div>
          </div>

          <!-- Formulario Publisher -->
          <div *ngIf="showPublisherForm" class="modal-overlay" (click)="showPublisherForm = false">
            <div class="modal-content" (click)="$event.stopPropagation()">
              <h3>{{ editingPublisher ? 'Editar Publisher' : 'Agregar Publisher' }}</h3>
              <form (ngSubmit)="savePublisher()" class="form">
                <div class="form-group">
                  <label>Nombre:</label>
                  <input
                    type="text"
                    [(ngModel)]="newPublisher.name"
                    name="publisherName"
                    required
                    class="form-input"
                  >
                </div>
                <div class="form-actions">
                  <button type="submit" class="btn btn-primary">💾 Guardar</button>
                  <button type="button" class="btn btn-secondary" (click)="showPublisherForm = false">❌ Cancelar</button>
                </div>
              </form>
            </div>
          </div>
        </div>

        <!-- Gestión de Consolas -->
        <div *ngIf="currentView === 'consoles'" class="master-management">
          <h2>🎮 Gestión de Consolas</h2>
          <div class="master-actions">
            <button class="btn btn-primary" (click)="showConsoleForm = true; editingConsole = null; newConsole = { id: 0, name: '' }">➕ Agregar Consola</button>
            <button class="btn btn-secondary" (click)="currentView = 'masters'">⬅️ Volver</button>
          </div>

          <div class="master-list">
            <div *ngFor="let console of consoles" class="master-item">
              <span>{{ console.name }}</span>
              <div class="item-actions">
                <button class="btn btn-edit" (click)="editConsole(console)">✏️</button>
                <button class="btn btn-delete" (click)="deleteConsole(console.id)">🗑️</button>
              </div>
            </div>
          </div>

          <!-- Formulario Consola -->
          <div *ngIf="showConsoleForm" class="modal-overlay" (click)="showConsoleForm = false">
            <div class="modal-content" (click)="$event.stopPropagation()">
              <h3>{{ editingConsole ? 'Editar Consola' : 'Agregar Consola' }}</h3>
              <form (ngSubmit)="saveConsole()" class="form">
                <div class="form-group">
                  <label>Nombre:</label>
                  <input
                    type="text"
                    [(ngModel)]="newConsole.name"
                    name="consoleName"
                    required
                    class="form-input"
                  >
                </div>
                <div class="form-actions">
                  <button type="submit" class="btn btn-primary">💾 Guardar</button>
                  <button type="button" class="btn btn-secondary" (click)="showConsoleForm = false">❌ Cancelar</button>
                </div>
              </form>
            </div>
          </div>
        </div>

        <!-- Gestión de Géneros -->
        <div *ngIf="currentView === 'genres'" class="master-management">
          <h2>🎯 Gestión de Géneros</h2>
          <div class="master-actions">
            <button class="btn btn-primary" (click)="showGenreForm = true; editingGenre = null; newGenre = { id: 0, name: '' }">➕ Agregar Género</button>
            <button class="btn btn-secondary" (click)="currentView = 'masters'">⬅️ Volver</button>
          </div>

          <div class="master-list">
            <div *ngFor="let genre of genres" class="master-item">
              <span>{{ genre.name }}</span>
              <div class="item-actions">
                <button class="btn btn-edit" (click)="editGenre(genre)">✏️</button>
                <button class="btn btn-delete" (click)="deleteGenre(genre.id)">🗑️</button>
              </div>
            </div>
          </div>

          <!-- Formulario Género -->
          <div *ngIf="showGenreForm" class="modal-overlay" (click)="showGenreForm = false">
            <div class="modal-content" (click)="$event.stopPropagation()">
              <h3>{{ editingGenre ? 'Editar Género' : 'Agregar Género' }}</h3>
              <form (ngSubmit)="saveGenre()" class="form">
                <div class="form-group">
                  <label>Nombre:</label>
                  <input
                    type="text"
                    [(ngModel)]="newGenre.name"
                    name="genreName"
                    required
                    class="form-input"
                  >
                </div>
                <div class="form-actions">
                  <button type="submit" class="btn btn-primary">💾 Guardar</button>
                  <button type="button" class="btn btn-secondary" (click)="showGenreForm = false">❌ Cancelar</button>
                </div>
              </form>
            </div>
          </div>
        </div>

        <!-- Gestión de Personas -->
        <div *ngIf="currentView === 'people'" class="master-management">
          <h2>👥 Gestión de Personas</h2>
          <div class="master-actions">
            <button class="btn btn-primary" (click)="showPeopleForm = true; editingPeople = null; newPeople = { id: 0, name: '', age: 0 }">➕ Agregar Persona</button>
            <button class="btn btn-secondary" (click)="currentView = 'masters'">⬅️ Volver</button>
          </div>

          <div class="master-list">
            <div *ngFor="let person of people" class="master-item">
              <span>{{ person.name }} ({{ person.age }} años)</span>
              <div class="item-actions">
                <button class="btn btn-edit" (click)="editPeople(person)">✏️</button>
                <button class="btn btn-delete" (click)="deletePeople(person.id)">🗑️</button>
              </div>
            </div>
          </div>

          <!-- Formulario Persona -->
          <div *ngIf="showPeopleForm" class="modal-overlay" (click)="showPeopleForm = false">
            <div class="modal-content" (click)="$event.stopPropagation()">
              <h3>{{ editingPeople ? 'Editar Persona' : 'Agregar Persona' }}</h3>
              <form (ngSubmit)="savePeople()" class="form">
                <div class="form-row">
                  <div class="form-group">
                    <label>Nombre:</label>
                    <input
                      type="text"
                      [(ngModel)]="newPeople.name"
                      name="peopleName"
                      required
                      class="form-input"
                    >
                  </div>
                  <div class="form-group">
                    <label>Edad:</label>
                    <input
                      type="number"
                      [(ngModel)]="newPeople.age"
                      name="peopleAge"
                      required
                      min="0"
                      class="form-input"
                    >
                  </div>
                </div>
                <div class="form-actions">
                  <button type="submit" class="btn btn-primary">💾 Guardar</button>
                  <button type="button" class="btn btn-secondary" (click)="showPeopleForm = false">❌ Cancelar</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </main>
    </div>

    <!-- User Selection Modal -->
    <div *ngIf="showUserSelection" class="modal-overlay">
      <div class="modal-content" (click)="$event.stopPropagation()">
        <h3>Seleccione el Usuario Actual</h3>
        <select [(ngModel)]="selectedUserId" class="form-input">
          <option value="0">Seleccione un usuario</option>
          <option *ngFor="let person of people" [value]="person.id">{{ person.name }}</option>
        </select>
        <div class="form-actions">
          <button (click)="selectUser()" class="btn btn-primary">Seleccionar</button>
        </div>
      </div>
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

    .user-selector {
      display: flex;
      align-items: center;
      gap: 10px;
      margin-bottom: 10px;
      justify-content: center;
    }

    .user-selector label {
      font-weight: bold;
      color: white;
    }

    .user-selector select {
      padding: 8px;
      border-radius: 5px;
      border: none;
      font-size: 14px;
    }

    .nav {
      display: flex;
      justify-content: center;
      gap: 15px;
      flex-wrap: wrap;
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

    .game-list h2, .game-form h2, .masters-menu h2, .master-management h2 {
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

    .form-input, .form-input select {
      width: 100%;
      padding: 12px;
      border: 2px solid #ddd;
      border-radius: 5px;
      font-size: 16px;
      transition: border-color 0.3s ease;
    }

    .form-input:focus, .form-input select:focus {
      outline: none;
      border-color: #667eea;
    }

    .form-actions {
      display: flex;
      gap: 15px;
      justify-content: center;
      margin-top: 30px;
    }

    .masters-menu {
      text-align: center;
    }

    .masters-grid {
      display: grid;
      grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
      gap: 20px;
      margin-top: 30px;
    }

    .master-card {
      background: #f8f9fa;
      border: 2px solid #e9ecef;
      border-radius: 10px;
      padding: 30px 20px;
      cursor: pointer;
      transition: all 0.3s ease;
      text-align: center;
    }

    .master-card:hover {
      border-color: #667eea;
      box-shadow: 0 4px 12px rgba(102, 126, 234, 0.2);
      transform: translateY(-2px);
    }

    .master-icon {
      font-size: 3em;
      margin-bottom: 15px;
    }

    .master-card h3 {
      margin: 0 0 10px 0;
      color: #333;
    }

    .master-card p {
      color: #666;
      margin: 0 0 15px 0;
      font-size: 14px;
    }

    .master-count {
      background: #667eea;
      color: white;
      padding: 4px 8px;
      border-radius: 12px;
      font-size: 12px;
      font-weight: bold;
    }

    .back-button {
      margin-top: 30px;
      text-align: center;
    }

    .master-management {
      max-width: 800px;
      margin: 0 auto;
    }

    .master-actions {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 20px;
      flex-wrap: wrap;
      gap: 10px;
    }

    .master-list {
      background: #f8f9fa;
      border-radius: 10px;
      padding: 20px;
    }

    .master-item {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 15px;
      border: 1px solid #e9ecef;
      border-radius: 8px;
      margin-bottom: 10px;
      background: white;
    }

    .master-item:last-child {
      margin-bottom: 0;
    }

    .item-actions {
      display: flex;
      gap: 10px;
    }

    .modal-overlay {
      position: fixed;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: rgba(0, 0, 0, 0.5);
      display: flex;
      justify-content: center;
      align-items: center;
      z-index: 1000;
    }

    .modal-content {
      background: white;
      padding: 30px;
      border-radius: 10px;
      box-shadow: 0 4px 20px rgba(0, 0, 0, 0.3);
      max-width: 500px;
      width: 90%;
    }

    .modal-content h3 {
      margin-top: 0;
      color: #333;
      text-align: center;
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

      .masters-grid {
        grid-template-columns: 1fr;
      }

      .master-actions {
        flex-direction: column;
        align-items: stretch;
      }
    }
  `]
})
export class GameFormComponent implements OnInit {
  games: Game[] = [];
  filteredGames: Game[] = [];
  searchTerm: string = '';
  currentView: 'list' | 'add' | 'masters' | 'publishers' | 'consoles' | 'genres' | 'people' = 'list';
  isEditing: boolean = false;

  // Data for dropdowns
  publishers: Publisher[] = [];
  consoles: Console[] = [];
  genres: Genre[] = [];
  people: any[] = [];

  // Form management
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

  currentUserId: number = 0;
  showUserSelection: boolean = false;
  selectedUserId: number = 0;
  isLoaded: boolean = false;

  // Master data forms
  showPublisherForm: boolean = false;
  showConsoleForm: boolean = false;
  showGenreForm: boolean = false;
  showPeopleForm: boolean = false;

  editingPublisher: Publisher | null = null;
  editingConsole: Console | null = null;
  editingGenre: Genre | null = null;
  editingPeople: any | null = null;

  newPublisher: Publisher = { id: 0, name: '' };
  newConsole: Console = { id: 0, name: '' };
  newGenre: Genre = { id: 0, name: '' };
  newPeople: any = { id: 0, name: '', age: 0 };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadGames();
    this.loadMastersData();
    setTimeout(() => {
      if (this.isLoaded) {
        const storedUserId = sessionStorage.getItem('currentUserId');
        if (storedUserId) {
          this.currentUserId = parseInt(storedUserId);
        } else {
          this.showUserSelection = true;
        }
      }
    }, 200);
  }

  loadGames() {
    this.http.get<Game[]>('https://localhost:7208/api/game').subscribe(
      (result) => {
        this.games = result;
        this.filteredGames = result;
      },
      (error) => {
        console.error('Error loading games:', error);
      }
    );
  }

  loadMastersData() {
    // Load publishers
    this.http.get<Publisher[]>('https://localhost:7208/api/publisher').subscribe(
      (result) => {
        this.publishers = result;
      },
      (error) => {
        console.error('Error loading publishers:', error);
      }
    );

    // Load consoles
    this.http.get<Console[]>('https://localhost:7208/api/console').subscribe(
      (result) => {
        this.consoles = result;
      },
      (error) => {
        console.error('Error loading consoles:', error);
      }
    );

    // Load genres
    this.http.get<Genre[]>('https://localhost:7208/api/genre').subscribe(
      (result) => {
        this.genres = result;
      },
      (error) => {
        console.error('Error loading genres:', error);
      }
    );

    // Load people
    this.http.get<any[]>('https://localhost:7208/api/people').subscribe(
      (result) => {
        this.people = result;
        this.isLoaded = true;
      },
      (error) => {
        console.error('Error loading people:', error);
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
      this.http.delete(`https://localhost:7208/api/game/${id}`).subscribe(
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
    const gameToSend = {
      id: this.game.id,
      name: this.game.name,
      year: this.game.year,
      publisherId: this.game.publisherId,
      consoleId: this.game.consoleId,
      genreId: this.game.genreId,
      quantity: this.game.quantity,
      price: this.game.price
    };

    const headers = { 'Current-User-Id': this.currentUserId.toString() };

    if (this.isEditing) {
      this.http.put(`https://localhost:7208/api/game/${this.game.id}`, gameToSend, { headers }).subscribe(
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
      this.http.post('https://localhost:7208/api/game', gameToSend, { headers }).subscribe(
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

  // Publisher management
  editPublisher(publisher: Publisher) {
    this.editingPublisher = publisher;
    this.newPublisher = { ...publisher };
    this.showPublisherForm = true;
  }

  deletePublisher(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar este publisher?')) {
      this.http.delete(`https://localhost:7208/api/publisher/${id}`).subscribe(
        () => {
          this.loadMastersData();
        },
        (error) => {
          console.error('Error deleting publisher:', error);
        }
      );
    }
  }

  savePublisher() {
    const headers = { 'Current-User-Id': this.currentUserId.toString() };
    if (this.editingPublisher) {
      this.http.put(`https://localhost:7208/api/publisher/${this.newPublisher.id}`, this.newPublisher, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showPublisherForm = false;
          this.editingPublisher = null;
        },
        (error) => {
          console.error('Error updating publisher:', error);
        }
      );
    } else {
      this.http.post('https://localhost:7208/api/publisher', this.newPublisher, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showPublisherForm = false;
          this.newPublisher = { id: 0, name: '' };
        },
        (error) => {
          console.error('Error adding publisher:', error);
        }
      );
    }
  }

  // Console management
  editConsole(console: Console) {
    this.editingConsole = console;
    this.newConsole = { ...console };
    this.showConsoleForm = true;
  }

  deleteConsole(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar esta consola?')) {
      this.http.delete(`https://localhost:7208/api/console/${id}`).subscribe(
        () => {
          this.loadMastersData();
        },
        (error) => {
          console.error('Error deleting console:', error);
        }
      );
    }
  }

  saveConsole() {
    const headers = { 'Current-User-Id': this.currentUserId.toString() };
    if (this.editingConsole) {
      this.http.put(`https://localhost:7208/api/console/${this.newConsole.id}`, this.newConsole, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showConsoleForm = false;
          this.editingConsole = null;
        },
        (error) => {
          console.error('Error updating console:', error);
        }
      );
    } else {
      this.http.post('https://localhost:7208/api/console', this.newConsole, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showConsoleForm = false;
          this.newConsole = { id: 0, name: '' };
        },
        (error) => {
          console.error('Error adding console:', error);
        }
      );
    }
  }

  // Genre management
  editGenre(genre: Genre) {
    this.editingGenre = genre;
    this.newGenre = { ...genre };
    this.showGenreForm = true;
  }

  deleteGenre(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar este género?')) {
      this.http.delete(`https://localhost:7208/api/genre/${id}`).subscribe(
        () => {
          this.loadMastersData();
        },
        (error) => {
          console.error('Error deleting genre:', error);
        }
      );
    }
  }

  saveGenre() {
    const headers = { 'Current-User-Id': this.currentUserId.toString() };
    if (this.editingGenre) {
      this.http.put(`https://localhost:7208/api/genre/${this.newGenre.id}`, this.newGenre, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showGenreForm = false;
          this.editingGenre = null;
        },
        (error) => {
          console.error('Error updating genre:', error);
        }
      );
    } else {
      this.http.post('https://localhost:7208/api/genre', this.newGenre, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showGenreForm = false;
          this.newGenre = { id: 0, name: '' };
        },
        (error) => {
          console.error('Error adding genre:', error);
        }
      );
    }
  }

  // People management
  editPeople(person: any) {
    this.editingPeople = person;
    this.newPeople = { ...person };
    this.showPeopleForm = true;
  }

  deletePeople(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar esta persona?')) {
      this.http.delete(`https://localhost:7208/api/people/${id}`).subscribe(
        () => {
          this.loadMastersData();
        },
        (error) => {
          console.error('Error deleting people:', error);
        }
      );
    }
  }

  savePeople() {
    const headers = { 'Current-User-Id': this.currentUserId.toString() };
    if (this.editingPeople) {
      this.http.put(`https://localhost:7208/api/people/${this.newPeople.id}`, this.newPeople, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showPeopleForm = false;
          this.editingPeople = null;
        },
        (error) => {
          console.error('Error updating people:', error);
        }
      );
    } else {
      this.http.post('https://localhost:7208/api/people', this.newPeople, { headers }).subscribe(
        () => {
          this.loadMastersData();
          this.showPeopleForm = false;
          this.newPeople = { id: 0, name: '', age: 0 };
        },
        (error) => {
          console.error('Error adding people:', error);
        }
      );
    }
  }

  selectUser() {
    if (this.selectedUserId > 0) {
      this.currentUserId = this.selectedUserId;
      sessionStorage.setItem('currentUserId', this.selectedUserId.toString());
      this.showUserSelection = false;
    }
  }
}
