# Prueba Técnica WTW – Gestión de Solicitudes

Este proyecto es una aplicación full stack desarrollada como parte de una prueba técnica para el rol de Líder Técnico. Permite la gestión de solicitudes mediante un frontend en Angular y un backend desarrollado en .NET 8 con arquitectura limpia, utilizando EF Core y persistencia en SQL Server.

---

##  Tecnologías utilizadas

- **Backend:** .NET 8, EF Core, Arquitectura limpia
- **Frontend:** Angular, Bootstrap
- **Base de datos:** SQL Server
- **DevOps:** Azure DevOps, Pipelines en YAML

---

##  Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 o superior)
- [Angular CLI](https://angular.io/cli)
- SQL Server local o remoto
- Visual Studio 2022 o VS Code (opcional)

---

##  Ejecución del Backend (SolicitudesApp)

1. **Ubícate en la carpeta del backend:**

```bash
cd SolicitudesApp
```

2. **Configura la cadena de conexión en **``**:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR_SQL;Database=SolicitudesDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

3. **Opción A: Usar archivo SQL para crear DB y tabla:**

- Ejecuta `BaseDeDatos.sql` desde SQL Server Management Studio.

4. **Opción B: Aplicar migraciones con EF Core:**

```bash
dotnet ef database update
```

5. **Ejecuta el backend:**

```bash
dotnet run
```

---

## Ejecución del Frontend (SolicitudesApp.Frontend)

1. **Ubícate en la carpeta del frontend:**

```bash
cd SolicitudesApp.Frontend
```

2. **Instala las dependencias:**

```bash
npm install
```

3. **Ejecuta la aplicación Angular:**

```bash
ng serve
```

Por defecto, estará disponible en `http://localhost:4200`.

> La interfaz de usuario está construida con Angular y utiliza Bootstrap para el diseño y los estilos responsivos.

---

## Estructura del Backend (Arquitectura limpia)

El backend está organizado siguiendo los principios de arquitectura limpia. Cada capa está contenida en un proyecto independiente:

```
SolicitudesApp/
├── SolicitudesApp.Domain/          # Entidades y contratos de dominio
├── SolicitudesApp.Application/     # Casos de uso, interfaces y DTOs
├── SolicitudesApp.Infrastructure/  # Acceso a datos (EF Core), implementaciones técnicas
├── SolicitudesApp.API/             # Punto de entrada, configuración de servicios y endpoints
```

---

## Base de Datos

- Si prefieres usar el script manual, puedes encontrar el archivo `BaseDeDatos.sql` en la raíz del proyecto. Este crea la base de datos `SolicitudesDB` y la tabla principal.
- También puedes usar las migraciones generadas con Entity Framework Core mediante el comando `dotnet ef database update`.

---

## CI/CD con Azure DevOps

El repositorio incluye un archivo `azure-pipelines.yml` para automatizar la integración y despliegue. El pipeline contempla:

- Build y test del backend
- Build del frontend
- Despliegue a ambiente QA

---

## Estructura del proyecto

```
PruebaWTW/
│
├── SolicitudesApp/               # Backend (.NET 8, arquitectura limpia)
├── SolicitudesApp.Frontend/      # Frontend (Angular + Bootstrap)
├── BaseDeDatos.sql               # Script para crear la base de datos
├── azure-pipelines.yml           # Pipeline CI/CD
├── devops-strategy.md            # Estrategia de despliegue
├── liderazgo-tecnico.md          # Preguntas de liderazgo técnico
└── README.md                     # Este archivo
```

---

## Respuestas Liderazgo técnico
Además del código fuente, el repositorio incluye el archivo `liderazgo-tecnico.md`, que contiene respuestas a preguntas sobre liderazgo técnico, abordando situaciones comunes en equipos de desarrollo. Este documento hace parte de los entregables requeridos en la prueba.


## Licencia

Este proyecto fue desarrollado exclusivamente como parte de una prueba técnica y no tiene fines comerciales.

