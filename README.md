# API.EMPRESA.CONF - Backend

## 📋 Descripción
API REST empresarial construida con .NET 8 Web API, optimizada con Dapper para acceso a datos mediante stored procedures de SQL Server. Sistema completo de gestión de empleados con operaciones CRUD.

## 🚀 Tecnologías Utilizadas
- **.NET 8** - Framework principal
- **ASP.NET Core Web API** - API RESTful
- **Dapper** - Micro-ORM para máximo rendimiento
- **SQL Server** - Base de datos
- **Stored Procedures** - Lógica de datos optimizada
- **C#** - Lenguaje de programación

## 📁 Estructura del Proyecto
```
HR-CORE-API/
├── .git/                           # Control de versiones Git
├── .github/                        # Configuración de GitHub
│   └── workflows/                  # GitHub Actions para CI/CD
├── API.EMPRESA.CONF/               # Proyecto principal de la API
│   ├── Controllers/
│   │   └── EmpleadoController.cs   # CRUD completo de empleados
│   ├── Models/
│   │   └── Empleado.cs            # Modelo de datos de empleado
│   ├── Services/
│   │   └── EmpleadoService.cs     # Lógica de negocio y acceso a datos
│   ├── Properties/                # Propiedades del proyecto
│   ├── API.EMPRESA.CONF.csproj    # Archivo de proyecto
│   ├── API.EMPRESA.CONF.http      # Archivo de pruebas HTTP
│   ├── Program.cs                 # Configuración principal y startup
│   ├── appsettings.json          # Configuración de producción
│   └── appsettings.Development.json # Configuración de desarrollo
├── Database/                       # Scripts de base de datos
│   └── bdd-empresa-crud.sql       # Script completo (BD + SPs + datos)
├── API.EMPRESA.CONF.sln           # Archivo de solución de Visual Studio
├── .gitignore                     # Archivos ignorados por Git
└── README.md                      # Documentación principal
```

## ⚡ Características Principales
- ✅ **CRUD Completo** de empleados (Create, Read, Update, Delete)
- ✅ **API RESTful** con endpoints optimizados
- ✅ **Stored Procedures** para máximo rendimiento en base de datos
- ✅ **Dapper** como micro-ORM con operaciones asíncronas
- ✅ **Async/Await** para operaciones no bloqueantes
- ✅ **CORS configurado** para integración con frontend
- ✅ **Swagger/OpenAPI** para documentación interactiva
- ✅ **Inyección de dependencias** nativa de .NET
- ✅ **Configuración por ambiente** (Development/Production)
- ✅ **GitHub Actions** para CI/CD automatizado

## 🔧 Instalación y Configuración

### Prerrequisitos
- .NET 8 SDK
- SQL Server (2019 o superior)
- Visual Studio 2022 o VS Code
- Git

### Pasos de instalación

#### 1. **Clonar el repositorio**
```bash
git clone https://github.com/jersonsv/hr-core-api.git
cd hr-core-api
```

#### 2. **Configurar la base de datos**
```sql
-- En SQL Server Management Studio, ejecutar:
-- Database/bdd-empresa-crud.sql (contiene todo: BD, tablas, SPs y datos de prueba)
```

#### 3. **Configurar connection string**
```json
// En appsettings.json
{
  "ConnectionStrings": {
    "BddSql": "Server=tu-servidor;Database=EmpresaGT;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

#### 4. **Restaurar dependencias y ejecutar**
```bash
# Desde la raíz del proyecto
dotnet restore

# Ejecutar la aplicación
dotnet run --project API.EMPRESA.CONF
```

#### 5. **Verificar instalación**
- API disponible en: `https://localhost:7000`
- Documentación Swagger: `https://localhost:7000/swagger`

## 📚 Endpoints API

### 🧑‍💼 Empleados
| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| `GET` | `/api/empleado` | Obtener todos los empleados | - |
| `GET` | `/api/empleado/{id}` | Obtener empleado por ID | `id: int` |
| `POST` | `/api/empleado` | Crear nuevo empleado | Body: `Empleado` |
| `PUT` | `/api/empleado/{id}` | Actualizar empleado existente | `id: int`, Body: `Empleado` |
| `DELETE` | `/api/empleado/{id}` | Eliminar empleado | `id: int` |

### 📝 Ejemplo de Payload (POST/PUT)
```json
{
  "nombre": "Juan Carlos Pérez",
  "numeroDocumento": "1234567890123",
  "sueldo": 5500
}
```

> 📖 **Documentación completa disponible en Swagger**: `https://localhost:7000/swagger` (al ejecutar en desarrollo)

## 🗄️ Base de Datos

### **Tabla Principal: Empleado**
```sql
CREATE TABLE Empleado (
    EmpleadoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    NumeroDocumento VARCHAR(13) UNIQUE NOT NULL,
    Sueldo INTEGER NOT NULL
);
```

### **Stored Procedures Implementados**
| Procedimiento | Función | Parámetros |
|---------------|---------|------------|
| `sp_listar_empleados` | Obtener todos los empleados | - |
| `sp_obtener_empleado` | Obtener empleado específico | `@EmpleadoID INT` |
| `sp_insertar_empleado` | Crear empleado | `@Nombre, @NumeroDocumento, @Sueldo` |
| `sp_actualizar_empleado` | Actualizar empleado | `@EmpleadoID, @Nombre, @NumeroDocumento, @Sueldo` |
| `sp_eliminar_empleado` | Eliminar empleado | `@EmpleadoID INT` |

### **Validaciones Implementadas**
- ✅ Número de documento único
- ✅ Campos obligatorios
- ✅ Validación de tipos de datos
- ✅ Manejo de errores SQL

### **Datos de Prueba Incluidos**
El script incluye 3 empleados de ejemplo con datos guatemaltecos para testing.

## 🧪 Testing
```bash
# Ejecutar tests unitarios (cuando estén implementados)
dotnet test

# Probar endpoints con curl
curl -X GET "https://localhost:7000/api/empleado" -H "accept: application/json"
```

## 🚀 Próximas Mejoras

### 📋 Roadmap
- [ ] **Arquitectura**
  - [ ] Implementar Repository Pattern
  - [ ] Implementar Unit of Work pattern
  - [ ] Agregar AutoMapper para DTOs
  
- [ ] **Seguridad**
  - [ ] Implementar autenticación JWT
  - [ ] Agregar autorización por roles
  - [ ] Implementar rate limiting
  
- [ ] **Calidad de Código**
  - [ ] Implementar Unit Tests con xUnit
  - [ ] Implementar Integration Tests
  - [ ] Agregar validaciones con FluentValidation
  - [ ] Implementar logging con Serilog
  
- [ ] **DevOps**
  - [ ] Containerización con Docker
  - [ ] Deployment automatizado
  - [ ] Monitoring y observabilidad

## 🌊 GitFlow - Flujo de Trabajo

Este proyecto implementa una **adaptación de GitFlow** basada exclusivamente en **Pull Requests** para garantizar la calidad del código.

### 🏗️ **Estructura de Ramas**
```
🏭 MAIN (Producción)     ←  Solo desde DEVELOP
   ↑ PR + Admin Review
   
🔧 DEVELOP (Integration) ←  Rama Default  
   ↑ ↑ ↑ PR + Team Review
   
⭐ FEATURES (Desarrollo individual)
```

- **`main`** - 🏭 **Producción**: Código estable listo para deploy
- **`develop`** - 🔧 **Integración**: Rama por defecto, últimas funcionalidades integradas  
- **`feature/*`** - ⭐ **Desarrollo individual**: Nuevas funcionalidades

### 🚀 **Flujo de Desarrollo**

#### 1️⃣ Para nuevas funcionalidades:
```bash
# Cambiar a develop y actualizar
git checkout develop
git pull origin develop

# Crear rama feature desde develop
git checkout -b feature/nombre-funcionalidad

# Desarrollar y hacer commits
git add .
git commit -m "feat: descripción de la funcionalidad"

# Push y crear PR hacia develop
git push origin feature/nombre-funcionalidad
```
> 📋 **Resultado**: PR automático hacia `develop` para **Team Review**

#### 2️⃣ Para pasar a producción:
```bash
# Solo administradores pueden crear PR desde develop hacia main
# PR require: Admin Review + All checks passed
```

### 🛡️ **Protecciones de Ramas**
- **`main`**: 🔒 Solo acepta PRs desde `develop` + Admin Review obligatorio
- **`develop`**: 🔒 Solo acepta PRs desde `feature/*` + Team Review obligatorio
- **Merge directo**: ❌ Prohibido en ambas ramas principales

### 🤖 **Validación Automática**
Este repositorio incluye **GitHub Actions** que validan automáticamente las reglas de GitFlow:

**📁 `.github/workflows/validar-pr-source.yml`**
- ✅ **Valida que PRs a `main`** solo vengan desde `develop`
- ✅ **Valida que PRs a `develop`** solo vengan desde `feature/*` o `hotfix/*`
- ❌ **Rechaza automáticamente** PRs que no cumplan las reglas
- 📊 **Logs detallados** con sugerencias de corrección

#### Ejemplos de validación:
```bash
✅ feature/nueva-funcionalidad → develop  # ✅ Válido
✅ develop → main                          # ✅ Válido  
❌ feature/algo → main                     # ❌ Error: usar develop como intermediario
❌ random-branch → develop                 # ❌ Error: usar prefijo feature/ o hotfix/
```

> 🎯 **Resultado**: Los PRs que no cumplan GitFlow fallarán automáticamente los checks, impidiendo el merge hasta corregir la estructura de ramas.

### 📋 **Convenciones de Nombres de Ramas**
- `feature/mejora-autenticacion`
- `feature/crud-departamentos`  
- `hotfix/correccion-validacion-sql`
- `release/v1.2.0`

## 🤝 Contribución

### Cómo contribuir
1. **Fork** el proyecto
2. **Crear** una rama siguiendo GitFlow (`git checkout -b feature/amazing-feature`)
3. **Commit** tus cambios siguiendo [Conventional Commits](https://www.conventionalcommits.org/)
4. **Push** a la rama (`git push origin feature/amazing-feature`)
5. **Abrir** un Pull Request hacia `develop`

### Estándares de código
- Seguir convenciones de C#/.NET
- Documentar métodos públicos
- Incluir tests para nuevas funcionalidades
- Mantener cobertura de tests > 80%

## 🐛 Reporte de Issues
Si encuentras un bug o tienes una sugerencia:
1. Verifica que no exista un issue similar
2. Crea un nuevo issue con:
   - Descripción clara del problema
   - Pasos para reproducir
   - Comportamiento esperado vs actual
   - Screenshots (si aplica)

## 📄 Licencia
Este proyecto está bajo la Licencia MIT. Ver [LICENSE](LICENSE) para más detalles.

## 👨‍💻 Autor
**Jerson Salvador**
- GitHub: [@jersonsv](https://github.com/jersonsv)
- Email: tu-email@ejemplo.com

---
⭐ Si este proyecto te fue útil, ¡no olvides darle una estrella!

## 📊 Estado del Proyecto
![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![Version](https://img.shields.io/badge/version-1.0.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)