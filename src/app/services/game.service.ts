import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game, Publisher, Console, Genre } from '../models/game.models';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = 'http://localhost:5142'; // Updated to match .NET backend port

  constructor(private http: HttpClient) { }

  // Games
  getAllGames(): Observable<Game[]> {
    return this.http.get<Game[]>(`${this.apiUrl}/GetAllGames/`);
  }

  getGameById(id: number): Observable<Game> {
    return this.http.get<Game>(`${this.apiUrl}/GetGameById/${id}`);
  }

  saveOrUpdateGame(game: Game): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(`${this.apiUrl}/SaveOrUpdateGame/`, game);
  }

  deleteGameById(id: number): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(`${this.apiUrl}/DeleteGameById/${id}`, {});
  }

  // Publishers
  getAllPublishers(): Observable<Publisher[]> {
    return this.http.get<Publisher[]>(`${this.apiUrl}/GetAllPublishers/`);
  }

  // Consoles
  getAllConsoles(): Observable<Console[]> {
    return this.http.get<Console[]>(`${this.apiUrl}/GetAllConsoles/`);
  }

  // Genres
  getAllGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${this.apiUrl}/GetAllGenres/`);
  }
}
