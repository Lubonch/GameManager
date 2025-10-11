# CrudWindowsFormsDataSet

CrudWindowsFormsDataSet es una aplicación de escritorio desarrollada en Windows Forms para gestionar juegos, géneros, editores, consolas y usuarios. Incluye funcionalidades de login, registro y operaciones CRUD completas, utilizando SQL Server como base de datos y DataSets para el manejo de datos.

## Características

- **Gestión de Juegos**: Agregar, editar, eliminar y listar juegos.
- **Gestión de Géneros**: Manejo de categorías de juegos.
- **Gestión de Editores**: Información sobre compañías desarrolladoras.
- **Gestión de Consolas**: Plataformas de juegos.
- **Gestión de Usuarios**: Login y registro de usuarios.
- **Interfaz Gráfica**: UI moderna con Material Design usando MaterialSkin.
- **Base de Datos**: Soporte para SQL Server con DataSets para acceso a datos.

## Tecnologías Utilizadas

- **.NET Framework 4.7.2**: Framework para el desarrollo de la aplicación.
- **Windows Forms**: Para la interfaz de usuario.
- **MaterialSkin**: Librería para temas Material Design.
- **SQL Server**: Base de datos relacional.
- **DataSets**: Para el mapeo y manejo de datos.
- **Visual Studio**: IDE recomendado.

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalados:

- **.NET Framework 4.7.2**: Incluido en Visual Studio o descargable por separado.
- **SQL Server**: Una instancia de SQL Server (local o remota).
- **Visual Studio**: Con soporte para Windows Forms y .NET Framework.
- **MaterialSkin NuGet Package**: Se instala automáticamente al restaurar paquetes.

## Instalación y Configuración

### 1. Clonar el Repositorio

```bash
git clone https://github.com/Lubonch/GameManager.git
cd GameManager
git checkout Backup/WinformsProject
```

### 2. Configurar la Base de Datos

- Restaura la base de datos usando el script en `databasebackup/bd.sql`:
  - Ejecuta el script en SQL Server Management Studio (SSMS) para crear la base de datos "CrudWindowsForm" y sus tablas.
- Alternativamente, restaura el backup desde `databasebackup/backup.bak` en SSMS.
- Actualiza la cadena de conexión en `CrudWindowsFormsDataSet\App.config` si es necesario (por ejemplo, cambiar "Server-Name" por tu servidor SQL).

Ejemplo de cadena de conexión:

```xml
<connectionStrings>
    <add name="CrudWindowsFormsDataSet.Properties.Settings.CrudWindowsFormConnectionString"
        connectionString="Data Source=YourServer;Initial Catalog=CrudWindowsForm;Integrated Security=SSPI;"
        providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Configurar el Proyecto

- Abre `CrudWindowsFormsDataSet.sln` en Visual Studio.
- Restaura los paquetes NuGet: Ve a Tools > NuGet Package Manager > Restore NuGet Packages.

## Cómo Ejecutar el Proyecto

1. En Visual Studio, establece `CrudWindowsFormsDataSet` como proyecto de inicio.
2. Presiona F5 o ejecuta en modo debug.
3. La aplicación se iniciará con la pantalla de Login.

### Verificar la Instalación

- Inicia sesión o regístrate como nuevo usuario.
- Navega por las diferentes secciones: Juegos, Géneros, Editores, Consolas.

## Estructura del Proyecto

```text
CrudWindowsFormsDataSet/
├── App.config                          # Configuración de la aplicación
├── Program.cs                          # Punto de entrada
├── Login.cs                            # Formulario de login
├── Register.cs                         # Formulario de registro
├── Home.cs                             # Formulario principal
├── Juego.cs                            # Gestión de juegos
├── Genero.cs                           # Gestión de géneros
├── Publisher.cs                        # Gestión de editores
├── Console.cs                          # Gestión de consolas
├── FrmPeople.cs                        # Gestión de personas/usuarios
├── DataSet1.xsd, DataSet2.xsd          # DataSets para datos
├── dsCrud.xsd, dsGame.xsd, etc.        # DataSets específicos
├── Properties/                         # Propiedades del proyecto
└── packages.config                     # Dependencias NuGet
```

## Contribución

1. Fork el proyecto.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Commit tus cambios (`git commit -am 'Agrega nueva funcionalidad'`).
4. Push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.

## Soporte

Si encuentras problemas, abre un issue en el repositorio de GitHub o contacta al equipo de desarrollo.

## Notas Adicionales

- La carpeta `databasebackup/` contiene respaldos de la base de datos.
- Asegúrate de que la instancia de SQL Server esté corriendo y accesible.
- Para desarrollo, usa el perfil "Debug" en Visual Studio.
