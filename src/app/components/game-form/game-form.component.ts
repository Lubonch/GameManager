import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GameService } from '../../services/game.service';
import { Game, Publisher, Console, Genre } from '../../models/game.models';

@Component({
  selector: 'app-game-form',
  templateUrl: './game-form.component.html',
  styleUrls: ['./game-form.component.css'],
  standalone: false
})
export class GameFormComponent implements OnInit {
  gameForm: FormGroup;
  isEditMode = false;
  gameId: number | null = null;
  loading = false;
  saving = false;
  error: string | null = null;

  publishers: Publisher[] = [];
  consoles: Console[] = [];
  genres: Genre[] = [];

  constructor(
    private fb: FormBuilder,
    private gameService: GameService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.gameForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      year: [new Date().getFullYear(), [Validators.required, Validators.min(1950), Validators.max(new Date().getFullYear() + 1)]],
      publisherId: ['', Validators.required],
      consoleId: ['', Validators.required],
      genreId: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(0)]],
      price: [0, [Validators.required, Validators.min(0)]]
    });
  }

  ngOnInit(): void {
    this.loadReferenceData();
    this.checkEditMode();
  }

  loadReferenceData(): void {
    // Load publishers
    this.gameService.getAllPublishers().subscribe({
      next: (publishers) => this.publishers = publishers,
      error: (error) => console.error('Error loading publishers:', error)
    });

    // Load consoles
    this.gameService.getAllConsoles().subscribe({
      next: (consoles) => this.consoles = consoles,
      error: (error) => console.error('Error loading consoles:', error)
    });

    // Load genres
    this.gameService.getAllGenres().subscribe({
      next: (genres) => this.genres = genres,
      error: (error) => console.error('Error loading genres:', error)
    });
  }

  checkEditMode(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.gameId = +params['id'];
        this.loadGame(this.gameId);
      }
    });
  }

  loadGame(id: number): void {
    this.loading = true;
    this.gameService.getGameById(id).subscribe({
      next: (game) => {
        this.gameForm.patchValue({
          name: game.name,
          year: new Date(game.year).getFullYear(),
          publisherId: game.publisher?.id,
          consoleId: game.console?.id,
          genreId: game.genre?.id,
          quantity: game.quantity,
          price: game.price
        });
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Error loading game: ' + error.message;
        this.loading = false;
      }
    });
  }

  onSubmit(): void {
    if (this.gameForm.valid) {
      this.saving = true;
      this.error = null;

      const formValue = this.gameForm.value;
      const game: Game = {
        id: this.gameId || 0,
        name: formValue.name,
        year: new Date(formValue.year, 0, 1), // January 1st of the year
        publisher: this.publishers.find(p => p.id === formValue.publisherId)!,
        console: this.consoles.find(c => c.id === formValue.consoleId)!,
        genre: this.genres.find(g => g.id === formValue.genreId)!,
        quantity: formValue.quantity,
        price: formValue.price
      };

      this.gameService.saveOrUpdateGame(game).subscribe({
        next: () => {
          this.saving = false;
          this.router.navigate(['/games']);
        },
        error: (error) => {
          this.error = 'Error saving game: ' + error.message;
          this.saving = false;
        }
      });
    } else {
      this.markFormGroupTouched();
    }
  }

  markFormGroupTouched(): void {
    Object.keys(this.gameForm.controls).forEach(key => {
      const control = this.gameForm.get(key);
      control?.markAsTouched();
    });
  }

  onCancel(): void {
    this.router.navigate(['/games']);
  }

  getFieldError(fieldName: string): string {
    const field = this.gameForm.get(fieldName);
    if (field?.errors && field.touched) {
      if (field.errors['required']) {
        return `${fieldName.charAt(0).toUpperCase() + fieldName.slice(1)} is required`;
      }
      if (field.errors['minlength']) {
        return `${fieldName.charAt(0).toUpperCase() + fieldName.slice(1)} must be at least ${field.errors['minlength'].requiredLength} characters`;
      }
      if (field.errors['min']) {
        return `${fieldName.charAt(0).toUpperCase() + fieldName.slice(1)} must be at least ${field.errors['min'].min}`;
      }
      if (field.errors['max']) {
        return `${fieldName.charAt(0).toUpperCase() + fieldName.slice(1)} cannot be greater than ${field.errors['max'].max}`;
      }
    }
    return '';
  }
}
