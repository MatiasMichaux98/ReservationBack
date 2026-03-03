# 🎬 ReservationBack - Sistema de Gestión de Reservas de Cine

![.NET](https://img.shields.io/badge/.NET-8.0-512bd4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-red?style=for-the-badge&logo=microsoft-sql-server)
![JWT](https://img.shields.io/badge/JWT-Auth-orange?style=for-the-badge&logo=json-web-tokens)

API REST  desarrollada con **ASP.NET Core** y **Entity Framework Core**. Gestión completa de cine: cartelera, salas, asientos y reservas con seguridad JWT.

---

## 🚀 Características Principales

* **Seguridad:** JWT e Identity Framework (Roles Admin/User).
* **Gestión:** CRUD de Películas, Géneros, Salas y Asientos.
* **Reservas:** Lógica de asignación de asientos por horario.
* **Background Services:** `ReservaExpirationService` para liberar asientos automáticamente.
* **Arquitectura:** Clean Architecture (Application, Infrastructure, Domain, API).
* **Seed Data:** Creación automática de base de datos, roles y admin al inicio.

---

## 🛠️ Stack Tecnológico

* **Backend:** .NET 8.0 Web API
* **Base de Datos:** Microsoft SQL Server
* **Autenticación:** Identity + JWT Bearer
* **Documentación:** Swagger (OpenAPI)

---
## 🏗️ Arquitectura

El proyecto sigue Clean Architecture dividida en:

- App.Api → Capa de presentación
- App.Application → Lógica de negocio
- App.Domain → Entidades y reglas de dominio
- App.Infrastructure → Persistencia y servicios externos
- ---

## ⚙️ Configuración e Instalación

## 📋 Prerrequisitos

tener instalado:

- Docker
- Docker Compose
- Git
- .NET 8 SDK (opcional)

Verificá:
docker --version  
docker compose version  

---

## 📥 Clonar el repositorio

git clone https://github.com/MatiasMichaux98/ReservationBack.git 
cd ReservationBack  

---

## ⚙️ Configurar variables de entorno

Creá un archivo `.env` en la raíz del proyecto:

DB_PASSWORD=Reserva.2026.SQL*  
API_PORT=5000  

- `DB_PASSWORD`: contraseña del usuario `sa` de SQL Server.  
- `API_PORT`: puerto donde se expondrá la API en tu máquina.  

---
## ⚙️ Configuración de appsettings.json

El archivo `App.Api/appsettings.json` contiene valores de ejemplo.

Antes de levantar el proyecto, reemplazá los siguientes campos:

### 🔐 ConnectionStrings

"ConnectionStrings": {
  "GetConnection": "Server=localhost,1434;Database=MoviePruebas;User Id=sa;Password=TU_PASSWORD_REAL;TrustServerCertificate=True;"
}

- Si usás Docker Compose, la conexión se sobreescribe automáticamente.
- Si ejecutás sin Docker, asegurate de que el servidor y la contraseña sean correctos.

---

### 👤 AdminUser

"AdminUser": {
  "Email": "admin@admin.com",
  "Password": "TU_PASSWORD_ADMIN",
  "FirstName": "Admin",
  "LastName": "System"
}

Este usuario se crea automáticamente al iniciar la aplicación.

⚠️ Cambiá la contraseña antes de usar en producción.

---

### 🔑 JWT

"JWT": {
  "Key": "TU_CLAVE_JWT_SUPER_LARGA",
  "Issuer": "SecureApi",
  "Audience": "SecureApiUser",
  "DurationInMinutes": 60
}

- `Key` debe ser una clave larga y segura (mínimo 16 caracteres).
- `DurationInMinutes` define cuánto tiempo dura el token.
## 🐳 Levantar la aplicación

Ejecutar:
docker compose up --build  

Esto levantará:

- SQL Server 2022 en localhost:1434  
- La API en http://localhost:5000  

---

## 🧠 Inicialización automática

Al iniciar por primera vez:

- Se crea la base de datos `MoviePruebas`
- Se ejecutan las migraciones
- Se crean los roles `Admin` y `User`
- Se crea un usuario administrador automáticamente

---

## 📄 Acceder a Swagger

http://localhost:5000/swagger  

Desde ahí podés probar todos los endpoints y autenticarte con JWT.