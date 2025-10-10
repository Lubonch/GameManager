# 🎮 Game Manager

Una aplicación completa de gestión de videojuegos construida con **.NET 8.0** (backend) y **Angular 20.3.4** (frontend).

## 🚀 Inicio Rápido

### Opción 1: Visual Studio (Recomendado)
1. Abre la solución `GameManagerWebAPI.sln` en Visual Studio
2. Selecciona el perfil **"Full Stack (API + Angular)"** en la lista desplegable de perfiles de ejecución
3. Presiona **F5** o el botón **Play** ▶️
4. Se abrirán automáticamente dos terminales:
   - Backend API: `http://localhost:5142`
   - Frontend Angular: `http://localhost:4200`

### Opción 2: Terminal Manual
```bash
# Terminal 1 - Backend
dotnet run --project GameManagerWebAPI.csproj

# Terminal 2 - Frontend
npm start
```

### Opción 3: Scripts Automáticos
```bash
# Desde la raíz del proyecto
./start-fullstack.bat

# O usando PowerShell
./start-fullstack.ps1

# O desde el directorio de Angular
npm run start:fullstack
```

## 📋 Características

### Backend (.NET 8.0)
- ✅ API REST completa con Swagger
- ✅ Gestión de Juegos, Publishers, Consoles y Genres
- ✅ NHibernate para persistencia de datos
- ✅ CORS configurado para desarrollo
- ✅ Documentación automática con OpenAPI

### Frontend (Angular 20.3.4)
- ✅ Interfaz moderna y responsiva
- ✅ Gestión completa de juegos (CRUD)
- ✅ Navegación intuitiva
- ✅ Formularios con validación
- ✅ Diseño adaptativo para móviles

## 🛠️ Tecnologías Utilizadas

### Backend
- **.NET 8.0** - Framework principal
- **ASP.NET Core Web API** - Framework web
- **NHibernate** - ORM para base de datos
- **AutoMapper** - Mapeo de objetos
- **Swashbuckle** - Documentación API

### Frontend
- **Angular 20.3.4** - Framework SPA
- **TypeScript 5.8.3** - Lenguaje de programación
- **RxJS 7.8.0** - Programación reactiva
- **Angular CLI 20.3.5** - Herramientas de desarrollo

## 📁 Estructura del Proyecto

```
GameManager/
├── GameManagerWebAPI.csproj          # Proyecto .NET
├── Program.cs                         # Punto de entrada backend
├── Controllers/                       # Controladores API
├── Services/                          # Lógica de negocio
├── Domain/                           # Modelos de datos
├── src/                              # Código fuente Angular
│   ├── app/
│   │   ├── components/               # Componentes Angular
│   │   ├── models/                   # Modelos TypeScript
│   │   ├── services/                 # Servicios Angular
│   │   └── ...
│   └── ...
├── start-fullstack.bat               # Script batch para iniciar ambos
├── start-fullstack.ps1               # Script PowerShell para iniciar ambos
└── package.json                      # Dependencias y scripts Angular
```

## 🔧 Configuración de Desarrollo

### Prerrequisitos
- **.NET 8.0 SDK** - [Descargar aquí](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Node.js 18+** - [Descargar aquí](https://nodejs.org/)
- **Visual Studio 2022** (opcional pero recomendado)

### Configuración Inicial
```bash
# Clonar el repositorio
git clone https://github.com/Lubonch/GameManager.git
cd GameManager

# Instalar dependencias de Angular
npm install

# El backend no requiere instalación adicional
```

## 🌐 URLs de Acceso

- **Aplicación Frontend:** `http://localhost:4200`
- **API Backend:** `http://localhost:5142`
- **Documentación API:** `http://localhost:5142/swagger`

## 📊 Estado del Proyecto

### ✅ Completado
- Actualización a .NET 8.0 y Angular 20.3.4
- Arquitectura completa backend/frontend
- Interfaz de usuario moderna
- Sistema de navegación completo
- Configuración de desarrollo optimizada

### 🚧 Próximos Pasos
- Integración completa con base de datos
- Autenticación y autorización
- Pruebas unitarias e integración
- Despliegue en producción

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📝 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

## 📞 Soporte

Si tienes preguntas o problemas:
1. Revisa la documentación
2. Abre un issue en GitHub
3. Contacta al equipo de desarrollo

---

**¡Disfruta desarrollando con Game Manager! 🎮✨**
