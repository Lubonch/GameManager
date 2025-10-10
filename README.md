# GameManager

Una aplicación full-stack para gestionar una colección de juegos, con backend en .NET 8 y frontend en Angular moderno. Este proyecto fue migrado y modernizado desde código legacy, reemplazando NHibernate por Entity Framework Core y actualizando a las últimas prácticas de desarrollo.

## Características

- **Backend (.NET 8)**: API RESTful completa con controladores para gestionar juegos, consolas, géneros, publishers, personas y autenticación.
- **Base de Datos**: SQL Server con Entity Framework Core, incluyendo migraciones automáticas y datos de ejemplo.
- **Frontend (Angular)**: Interfaz moderna con componentes standalone, gestión completa de maestros y formularios con dropdowns.
- **Sistema de Maestros**: Gestión CRUD completa para Publishers, Consolas, Géneros y Personas con navegación intuitiva.
- **CORS**: Configurado para permitir conexiones entre frontend y backend.
- **Swagger**: Documentación interactiva de la API.

## Tecnologías Utilizadas

- **Backend**:
  - .NET 8
  - ASP.NET Core Web API
  - Entity Framework Core 9.0
  - SQL Server (LocalDB)
  - Swashbuckle (Swagger)

- **Frontend**:
  - Angular 17+ (standalone components)
  - TypeScript
  - HttpClient para llamadas API

- **Herramientas**:
  - Git
  - Visual Studio / VS Code

## Instalación

### Prerrequisitos
- .NET 8 SDK
- Node.js y npm
- SQL Server (o LocalDB incluido en Visual Studio)

### Pasos
1. Clona el repositorio:
   ```bash
   git clone https://github.com/Lubonch/GameManager.git
   cd GameManager
   ```

2. Restaura dependencias del backend:
   ```bash
   cd GameManager.Server
   dotnet restore
   ```

3. Aplica migraciones de base de datos:
   ```bash
   dotnet ef database update
   ```

4. Restaura dependencias del frontend:
   ```bash
   cd ../gamemanager.client
   npm install
   ```

5. Construye el proyecto:
   ```bash
   dotnet build ../GameManager.Server
   ng build
   ```

## Uso

### Ejecutar el Backend
```bash
cd GameManager.Server
dotnet run
```
Accede a la API en `https://localhost:5001` y Swagger en `https://localhost:5001/swagger`.

### Ejecutar el Frontend
```bash
cd gamemanager.client
ng serve
```
Accede a la aplicación en `http://localhost:4200`.

### Ejecutar Ambos Simultáneamente
Usa Visual Studio para ejecutar el proyecto completo, o configura un script para lanzar backend y frontend.

## API Endpoints

### Juegos
- `GET /api/game` - Listar juegos con relaciones
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
curl -X GET "https://localhost:5001/api/game" -H "accept: application/json"
```

## Estructura del Proyecto

```
GameManager/
??? GameManager.Server/          # Backend .NET
?   ??? Controllers/             # Controladores API
?   ??? Models/                  # Modelos de datos
?   ??? Services/                # Lógica de negocio
?   ??? Data/                    # Contexto EF Core
?   ??? Migrations/              # Migraciones DB
??? gamemanager.client/          # Frontend Angular
?   ??? src/app/
?   ?   ??? components/          # Componentes
?   ?   ??? app.component.ts     # Componente principal
?   ??? angular.json
??? .gitignore                   # Archivos ignorados
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
- **Reemplazo de NHibernate por EF Core**: Eliminadas configuraciones manuales de mapeo y repositorios.
- **Actualización a .NET 8 y Angular standalone**: Componentes modernos y mejores prácticas.
- **Mejora de arquitectura**: Inyección de dependencias, async/await, y separación de responsabilidades.
- **DTOs agregados**: Para separar modelos de base de datos de respuestas API.
- **Inicialización de datos**: Script automático con datos de ejemplo.
- **Helpers y utilidades**: Respuestas API estandarizadas y mapeo automático.
- **Eliminación de código obsoleto**: Repositorios, configuraciones NHibernate y archivos legacy.

### Elementos migrados desde la carpeta `old`:
- ? **Modelos de dominio**: Game, Console, Genre, Publisher, People, LoginTable (nombres respetados)
- ? **Controladores**: Todos los controladores con endpoints RESTful modernos
- ? **Servicios**: Lógica de negocio con async/await y EF Core
- ? **DTOs**: Para todas las entidades con mapeo automático
- ? **Inicialización de DB**: Datos de ejemplo automáticos
- ? **Scripts SQL Legacy**: Recuperados en `GameManager.Server/database/scripts/` para referencia
- ? **Nombres de Tablas**: Respetados los nombres originales (Console, Games, Genres, etc.)
- ? **Configuraciones NHibernate**: No necesarias con EF Core
- ? **Repositorios manuales**: Reemplazados por DbContext de EF Core