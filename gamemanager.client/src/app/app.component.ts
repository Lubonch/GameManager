import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameFormComponent } from './components/game-form/game-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, GameFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Game Manager - Gestión de Juegos';
}

