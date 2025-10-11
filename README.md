# Game Manager

Aplicación full-stack para gestión de videojuegos, desarrollada con .NET 8 (backend) y Angular 18 (frontend). Incluye auditoría completa, selección de usuario y gestión de maestros (publishers, consolas, géneros, personas).

## Características

- Gestión completa de videojuegos: CRUD con validaciones
- Auditoría automática: Rastreo de creación/modificación con usuario y timestamps
- Selección de usuario: Modal al iniciar para elegir el usuario actual
- Gestión de maestros: Publishers, consolas, géneros y personas
- API RESTful: Endpoints modernos con EF Core
- Frontend responsivo: Angular standalone con formularios reactivos
- Base de datos SQL Server: Migraciones automáticas
- Inicialización de datos: Datos de ejemplo incluidos

## Requisitos

- .NET 8 SDK
- Node.js 18+
- SQL Server (o LocalDB)
- Angular CLI 18+

## Instalación y Ejecución

### Backend
```bash
cd GameManager.Server
dotnet restore
dotnet ef database update  # Aplica migraciones
dotnet run
```
Servidor disponible en: `https://localhost:7208`

### Frontend
```bash
cd gamemanager.client
npm install
ng serve
```
Aplicación disponible en: `http://localhost:4200`

### Base de Datos
- Las migraciones crean automáticamente las tablas.
- Datos de ejemplo se inicializan en `DbInitializer.cs`.

## API Endpoints

Todos los endpoints requieren el header `Current-User-Id` para auditoría (excepto GET).

### Juegos
- `GET /api/game` - Listar juegos
- `GET /api/game/{id}` - Obtener juego específico
- `POST /api/game` - Crear nuevo juego
- `PUT /api/game/{id}` - Actualizar juego
- `DELETE /api/game/{id}` - Eliminar juego

### Publishers
- `GET /api/publisher` - Listar publishers
- `GET /api/publisher/{id}` - Obtener publisher específico
- `POST /api/publisher` - Crear nuevo publisher
- `PUT /api/publisher/{id}` - Actualizar publisher
- `DELETE /api/publisher/{id}` - Eliminar publisher

### Consolas
- `GET /api/console` - Listar consolas
- `GET /api/console/{id}` - Obtener consola específica
- `POST /api/console` - Crear nueva consola
- `PUT /api/console/{id}` - Actualizar consola
- `DELETE /api/console/{id}` - Eliminar consola

### Géneros
- `GET /api/genre` - Listar géneros
- `GET /api/genre/{id}` - Obtener género específico
- `POST /api/genre` - Crear nuevo género
- `PUT /api/genre/{id}` - Actualizar género
- `DELETE /api/genre/{id}` - Eliminar género

### Personas
- `GET /api/people` - Listar personas
- `GET /api/people/{id}` - Obtener persona específica
- `POST /api/people` - Crear nueva persona
- `PUT /api/people/{id}` - Actualizar persona
- `DELETE /api/people/{id}` - Eliminar persona

### Autenticación
- `GET /api/logintable` - Listar usuarios
- `POST /api/logintable` - Crear nuevo usuario
- `PUT /api/logintable/{id}` - Actualizar usuario
- `DELETE /api/logintable/{id}` - Eliminar usuario

Ejemplo de uso con curl:
```bash
curl -X GET "https://localhost:7208/api/game" -H "accept: application/json"
curl -X POST "https://localhost:7208/api/game" -H "Content-Type: application/json" -H "Current-User-Id: 1" -d '{"name":"Nuevo Juego","year":"2023-01-01","publisherId":1,"consoleId":1,"genreId":1,"quantity":10,"price":50.0}'
```

## Modelos de Datos

Todos los modelos incluyen campos de auditoría:
- `CreatedAt`: Fecha de creación
- `UpdatedAt`: Fecha de última modificación
- `CreatedById`: ID del usuario que creó
- `UpdatedById`: ID del usuario que modificó

### Game
```csharp
public class Game {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Year { get; set; }
    public int PublisherId { get; set; }
    public int ConsoleId { get; set; }
    public int GenreId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    // Campos de auditoría...
}
```

## Estructura del Proyecto

```
GameManager/
??? GameManager.Server/          # Backend .NET
?   ??? Controllers/             # Controladores API
?   ??? Models/                  # Modelos de datos con auditoría
?   ??? Services/                # Lógica de negocio
?   ??? Data/                    # Contexto EF Core
?   ??? Migrations/              # Migraciones DB
?   ??? DTOs/                    # DTOs para API
??? gamemanager.client/          # Frontend Angular
?   ??? src/app/
?       ??? components/          # Componentes
?       ??? app.component.ts     # Componente principal
??? databasebackup/              # Backups SQL
??? README.md                    # Este archivo
```

## Contribución

1. Fork el proyecto.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Commit tus cambios (`git commit -am 'Agrega nueva funcionalidad'`).
4. Push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

## Notas de Migración

Este proyecto fue modernizado desde código legacy:
- Reemplazo de NHibernate por EF Core: Eliminadas configuraciones manuales de mapeo y repositorios.
- Actualización a .NET 8 y Angular standalone: Componentes modernos y mejores prácticas.
- Mejora de arquitectura: Inyección de dependencias, async/await, y separación de responsabilidades.
- DTOs agregados: Para separar modelos de base de datos de respuestas API.
- Auditoría completa: Campos automáticos en todos los modelos.
- Selección de usuario: Modal al iniciar para elegir usuario actual.
- Inicialización de datos: Script automático con datos de ejemplo.
- Helpers y utilidades: Respuestas API estandarizadas y mapeo automático.
- Eliminación de código obsoleto: Repositorios, configuraciones NHibernate y archivos legacy.

### Elementos migrados:
- Modelos de dominio: Game, Console, Genre, Publisher, People, LoginTable (nombres respetados)
- Controladores: Todos los controladores con endpoints RESTful modernos
- Servicios: Lógica de negocio con async/await y EF Core
- DTOs: Para todas las entidades con mapeo automático
- Auditoría: Campos `CreatedAt`, `UpdatedAt`, `CreatedById`, `UpdatedById` en todos los modelos
- Selección de usuario: Modal en frontend con `sessionStorage`
- Inicialización de DB: Datos de ejemplo automáticos
- Scripts SQL Legacy: Recuperados en `databasebackup/` para referencia
- Nombres de Tablas: Respetados los nombres originales (Console, Games, Genres, etc.)
- Configuraciones NHibernate: No necesarias con EF Core
- Repositorios manuales: Reemplazados por DbContext de EF Core- ? **Repositorios manuales**: Reemplazados por DbContext de EF Core