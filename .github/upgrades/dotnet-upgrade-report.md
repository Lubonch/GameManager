# .NET 8.0 Upgrade Report

## Project target framework modifications

| Project name                                   | Old Target Framework    | New Target Framework         | Commits                   |
|:-----------------------------------------------|:-----------------------:|:----------------------------:|---------------------------|
| GameManagerWebAPI.csproj                      |   net7.0                | net8.0                       | 6fe73c4a                  |

## NuGet Packages

| Package Name                               | Old Version | New Version | Commit Id                |
|:-------------------------------------------|:-----------:|:-----------:|--------------------------|
| Microsoft.AspNetCore.OpenApi              |   7.0.9     |  8.0.20     | 8011e719                 |
| Microsoft.VisualStudio.Web.CodeGeneration.Design |   7.0.8     |  8.0.7      | 8011e719                 |
| Newtonsoft.Json                            |  13.0.3     | 13.0.4      | 8011e719                 |
| Nhibernate                                 |   5.4.3     |  5.6.0      | 8011e719                 |
| System.Data.SqlClient                      |   4.8.5     |  4.9.0      | 8011e719                 |
| System.Linq                                |   4.3.0     | Removed     | 8011e719                 |
| System.Linq.Expressions                    |   4.3.0     | Removed     | 8011e719                 |
| System.Linq.Queryable                      |   4.3.0     | Removed     | 8011e719                 |

## All commits

| Commit ID              | Description                                |
|:-----------------------|:-------------------------------------------|
| a32e4bcf               | Commit upgrade plan                        |
| 6fe73c4a               | Upgrade project to .NET 8.0               |
| 0a5eca66               | Commit changes before fixing errors        |
| 8011e719               | Update GameManagerWebAPI.csproj dependencies |

## Project feature upgrades

### GameManagerWebAPI.csproj

Here is what changed for the project during upgrade:

- **Target Framework Upgrade**: Successfully upgraded from .NET 7.0 to .NET 8.0 to take advantage of the latest features, performance improvements, and security updates available in the newer framework version.

- **NuGet Package Updates**: Updated multiple packages to compatible versions for .NET 8.0:
  - Microsoft.AspNetCore.OpenApi: 7.0.9 → 8.0.20 (recommended for .NET 8.0)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design: 7.0.8 → 8.0.7 (recommended for .NET 8.0)
  - Newtonsoft.Json: 13.0.3 → 13.0.4 (recommended for .NET 8.0)

- **Security Vulnerability Fixes**: Updated packages with known security vulnerabilities:
  - Nhibernate: 5.4.3 → 5.6.0 (security vulnerability addressed)
  - System.Data.SqlClient: 4.8.5 → 4.9.0 (security vulnerability addressed)

- **Framework Integration**: Removed redundant packages that are now included in the .NET 8.0 framework:
  - Removed System.Linq package (functionality included with framework reference)
  - Removed System.Linq.Expressions package (functionality included with framework reference)
  - Removed System.Linq.Queryable package (functionality included with framework reference)

## Next steps

- Consider upgrading your Angular frontend to a more modern version to complement the backend upgrade
- Test the application thoroughly to ensure all functionality works correctly with .NET 8.0
- Review application performance improvements that may be available with .NET 8.0
- Consider leveraging new .NET 8.0 features in future development