
---

# 📜 README.md — LicoreriaSolution

```markdown
# 🍷 LicoreriaSolution

Proyecto académico en **.NET 8 + PostgreSQL** con arquitectura **Clean Architecture**.  
Incluye:
- API REST en **ASP.NET Core**
- Persistencia con **Entity Framework Core + Npgsql**
- Frontend básico en **HTML + CSS + JavaScript**
- Pruebas unitarias con **xUnit + Moq**

---

## 📂 Arquitectura

La solución está organizada en capas siguiendo Clean Architecture:

```

LicoreriaSolution/
├── Core.Domain/          # Entidades del dominio (Producto, Inventario, Proveedor, Persona)
├── Core.Application/     # Interfaces y lógica de negocio
├── Infrastructure/       # DbContext y repositorios (PostgreSQL con EF Core)
│   └── Persistence/AppDbContext.cs
├── Presentation.Api/     # API REST (ASP.NET Core Web API)
│   └── appsettings.json
├── Tests.Unit/           # Pruebas unitarias con xUnit + Moq
└── Frontend/             # index.html, styles.css y app.js para consumir la API

````

---

## 🗄️ Base de Datos

Se usa **PostgreSQL**.  

### Crear base de datos y usuario
En **pgAdmin → Query Tool**:

```sql
CREATE USER ferney WITH PASSWORD '123456';
CREATE DATABASE "LicoreriaDb" OWNER ferney;
GRANT ALL PRIVILEGES ON DATABASE "LicoreriaDb" TO ferney;
````

---

## ⚙️ Configuración

En `Presentation.Api/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=LicoreriaDb;Username=ferney;Password=123456"
}
```

En `Program.cs`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## 🚀 Migraciones EF Core

1. Eliminar migraciones viejas (si es necesario).
2. Crear una migración limpia:

```powershell
Add-Migration InitPostgresClean
Update-Database
```

3. Verificar tablas en **pgAdmin** → `LicoreriaDb` → Schemas → public → Tables.

---

## 📡 Endpoints principales

### Productos

* `GET /api/productos` → Lista todos los productos
* `GET /api/productos/{id}` → Obtiene un producto por ID
* `POST /api/productos` → Crea un producto
* `PUT /api/productos/{id}` → Edita un producto
* `DELETE /api/productos/{id}` → Elimina un producto

Ejemplo `POST`:

```json
{
  "nombre": "Ron Medellín",
  "descripcion": "Añejo 8 años",
  "precio": 75000
}
```

---

## 🖼️ Frontend

En la carpeta **Frontend**:

* `index.html` → interfaz web
* `styles.css` → estilos básicos
* `app.js` → llamadas `fetch` a la API

Abrir `index.html` en el navegador para consumir los endpoints.

---

## 🧪 Pruebas Unitarias

Proyecto `Tests.Unit` con **xUnit + Moq**.

Ejemplo de prueba: verificar que al crear un producto el repositorio se invoque una sola vez.

Ejecutar en Visual Studio:
Menú → **Prueba → Ejecutar todas las pruebas**.

---

## 📋 Requisitos

* Visual Studio 2022
* .NET SDK 8.0
* PostgreSQL 15+ (con pgAdmin 4)

---

## 👨‍💻 Autor

**Ferney Sánchez Parra**
Proyecto académico — Análisis y Desarrollo de Software

```

---
