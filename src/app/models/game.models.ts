export interface Game {
  id: number;
  name: string;
  year: Date;
  publisher: Publisher;
  console: Console;
  genre: Genre;
  quantity: number;
  price: number;
}

export interface Publisher {
  id: number;
  name: string;
}

export interface Console {
  id: number;
  name: string;
}

export interface Genre {
  id: number;
  name: string;
}
