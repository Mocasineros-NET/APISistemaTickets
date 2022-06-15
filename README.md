# APISistemaTickets
API del Sistema de Tickets para la materia de Sistemas de Información

## Como compilar el sistema

Para compilar el sistema se debe instalar el SDK de .NET 6.
Una vez instalado, se debe abrir una consola en la carpeta del proyecto y ejecutar `dotnet build`

## Como ejecutar la API localmente

Para correr el sistema se debe ejecutar `dotnet run`

## Archivo de solución

La solución tiene como target .NET 6, por lo tanto, para abrir el proyecto se debe usar Visual Studio 2022 o JetBrains Rider.

## Despliegue

Para hacer un despliegue de la aplicación se debe publicar la API como AppService en un servidor Linux o Windows y agregar el ConnectionString de SQL Server.

Las migraciones se ejecutan automáticamente.
