# .NET 8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade GameManagerWebAPI.csproj to .NET 8.0

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                        | Current Version | New Version | Description                         |
|:----------------------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Microsoft.AspNetCore.OpenApi                       |     7.0.9       |   8.0.20    | Recommended for .NET 8.0           |
| Microsoft.VisualStudio.Web.CodeGeneration.Design   |     7.0.8       |   8.0.7     | Recommended for .NET 8.0           |
| Newtonsoft.Json                                     |    13.0.3       |  13.0.4     | Recommended for .NET 8.0           |
| Nhibernate                                          |     5.4.3       |   5.6.0     | Security vulnerability              |
| System.Data.SqlClient                               |     4.8.5       |   4.9.0     | Security vulnerability              |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### GameManagerWebAPI.csproj modifications

Project properties changes:
  - Target framework should be changed from `net7.0` to `net8.0`

NuGet packages changes:
  - Microsoft.AspNetCore.OpenApi should be updated from `7.0.9` to `8.0.20` (*recommended for .NET 8.0*)
  - Microsoft.VisualStudio.Web.CodeGeneration.Design should be updated from `7.0.8` to `8.0.7` (*recommended for .NET 8.0*)
  - Newtonsoft.Json should be updated from `13.0.3` to `13.0.4` (*recommended for .NET 8.0*)
  - Nhibernate should be updated from `5.4.3` to `5.6.0` (*security vulnerability*)
  - System.Data.SqlClient should be updated from `4.8.5` to `4.9.0` (*security vulnerability*)
  - System.Linq should be removed `4.3.0` (*functionality included with framework reference*)
  - System.Linq.Expressions should be removed `4.3.0` (*functionality included with framework reference*)
  - System.Linq.Queryable should be removed `4.3.0` (*functionality included with framework reference*)

Other changes:
  - AutoMapper.Extensions.Microsoft.DependencyInjection package is deprecated but functionality is included directly in AutoMapper