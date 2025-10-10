# GameManager

Una aplicación full-stack para gestionar una colección de juegos, con backend en .NET 8 y frontend en Angular moderno. Este proyecto fue migrado y modernizado desde código legacy, reemplazando NHibernate por Entity Framework Core y actualizando a las últimas prácticas de desarrollo.

## Características

- **Backend (.NET 8)**: API RESTful con controladores para gestionar juegos, consolas, géneros, publishers, personas y autenticación.
- **Base de Datos**: SQL Server con Entity Framework Core, incluyendo migraciones automáticas.
- **Frontend (Angular)**: Interfaz moderna con componentes standalone, integrada con la API del backend.
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

- **Games**: `/api/game` (GET, POST, PUT, DELETE)
- **Consoles**: `/api/console` (GET, POST, PUT, DELETE)
- **Genres**: `/api/genre` (GET, POST, PUT, DELETE)
- **Publishers**: `/api/publisher` (GET, POST, PUT, DELETE)
- **People**: `/api/people` (GET, POST, PUT, DELETE)
- **LoginTable**: `/api/logintable` (GET, POST, PUT, DELETE)

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
- ? **Modelos de dominio**: Game, Console (?GameConsole), Genre, Publisher, People, LoginTable
- ? **Controladores**: Todos los controladores con endpoints RESTful modernos
- ? **Servicios**: Lógica de negocio con async/await y EF Core
- ? **DTOs**: Para todas las entidades con mapeo automático
- ? **Inicialización de DB**: Datos de ejemplo automáticos
- ? **Configuraciones NHibernate**: No necesarias con EF Core
- ? **Repositorios manuales**: Reemplazados por DbContext de EF Core
- ? **Scripts SQL legacy**: Reemplazados por migraciones EF Core