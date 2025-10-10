import { Component, OnInit } from '@angular/core';
import { Console } from '../../models/game.models';

@Component({
  selector: 'app-console-list',
  templateUrl: './console-list.component.html',
  styleUrls: ['./console-list.component.css'],
  standalone: false
})
export class ConsoleListComponent implements OnInit {
  consoles: Console[] = [];
  loading = false;
  error: string | null = null;

  ngOnInit(): void {
    this.loadConsoles();
  }

  loadConsoles(): void {
    this.loading = true;
    // Mock data
    this.consoles = [
      { id: 1, name: 'PlayStation 5' },
      { id: 2, name: 'Xbox Series X' },
      { id: 3, name: 'Nintendo Switch' },
      { id: 4, name: 'PlayStation 4' },
      { id: 5, name: 'Xbox One' }
    ];
    this.loading = false;
  }

  onDeleteConsole(id: number): void {
    if (confirm('Are you sure you want to delete this console?')) {
      this.consoles = this.consoles.filter(c => c.id !== id);
    }
  }
}
