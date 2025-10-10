import { Component, OnInit } from '@angular/core';
import { Publisher } from '../../models/game.models';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html',
  styleUrls: ['./publisher-list.component.css'],
  standalone: false
})
export class PublisherListComponent implements OnInit {
  publishers: Publisher[] = [];
  loading = false;
  error: string | null = null;

  // Mock data for now - in a real app this would come from a service
  ngOnInit(): void {
    this.loadPublishers();
  }

  loadPublishers(): void {
    this.loading = true;
    // Mock data
    this.publishers = [
      { id: 1, name: 'Nintendo' },
      { id: 2, name: 'Sony Interactive Entertainment' },
      { id: 3, name: 'Microsoft Game Studios' },
      { id: 4, name: 'Electronic Arts' },
      { id: 5, name: 'Ubisoft' }
    ];
    this.loading = false;
  }

  onDeletePublisher(id: number): void {
    if (confirm('Are you sure you want to delete this publisher?')) {
      // Mock delete
      this.publishers = this.publishers.filter(p => p.id !== id);
    }
  }
}
