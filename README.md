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
API.EMPRESA.CONF/
├── Controllers/
│   └── EmpleadoController.cs     # CRUD completo de empleados
├── Models/
│   └── Empleado.cs              # Modelo de datos de empleado
├── Services/
│   └── EmpleadoService.cs       # Lógica de negocio
├── Data/                        # Acceso a datos con Dapper
├── Database/
│   └── bdd-empresa-crud.sql     # Script completo (BD + SPs + datos)
├── Properties/
├── Connected Services/
├── Program.cs                   # Configuración principal
└── appsettings.json            # Configuración de la aplicación
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

## 🔧 Instalación y Configuración

### Prerrequisitos
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 o VS Code

### Pasos de instalación
1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/tu-usuario/api-empresa-conf.git
   cd api-empresa-conf
   ```

2. **Configurar la base de datos**
   ```sql
   -- En SQL Server Management Studio, ejecutar:
   -- Database/bdd-empresa-crud.sql (contiene todo: BD, tablas, SPs y datos de prueba)
   ```

3. **Configurar connection string**
   ```json
   // En appsettings.json
   {
     "ConnectionStrings": {
       "BddSql": "Server=tu-servidor;Database=EmpresaGT;Trusted_Connection=true;"
     }
   }
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet restore
   dotnet run
   ```

## 📚 Endpoints API

### Empleados
- `GET /api/empleado` - Obtener todos los empleados
- `GET /api/empleado/{id}` - Obtener empleado por ID
- `POST /api/empleado` - Crear nuevo empleado
- `PUT /api/empleado/{id}` - Actualizar empleado existente
- `DELETE /api/empleado/{id}` - Eliminar empleado

> 📖 **Documentación completa disponible en Swagger**: `https://localhost:7000/swagger` (al ejecutar en desarrollo)

## 🗄️ Base de Datos
La aplicación utiliza SQL Server con stored procedures para optimizar el rendimiento:

### **Tabla Principal: Empleado**
- `EmpleadoID` (INT, IDENTITY) - Clave primaria
- `Nombre` (VARCHAR(100)) - Nombre completo
- `NumeroDocumento` (VARCHAR(13)) - DPI/Cédula única
- `Sueldo` (INTEGER) - Salario del empleado

### **Stored Procedures Implementados:**
- `sp_listar_empleados` - Obtener todos los empleados
- `sp_obtener_empleado(@EmpleadoID)` - Obtener empleado específico
- `sp_insertar_empleado()` - Crear empleado (con validación de documento único)
- `sp_actualizar_empleado()` - Actualizar empleado (con validación)
- `sp_eliminar_empleado(@EmpleadoID)` - Eliminar empleado

### **Datos de Prueba Incluidos:**
- 3 empleados de ejemplo con datos guatemaltecos

## 🚀 Próximas Mejoras
- [ ] Implementar Repository Pattern
- [ ] Agregar autenticación JWT
- [ ] Implementar logging con Serilog
- [ ] Agregar validaciones con FluentValidation
- [ ] Implementar Unit of Work pattern
- [ ] Agregar documentación con Swagger

## 🤝 Contribución
Las contribuciones son bienvenidas. Por favor, crea un fork del proyecto y envía un pull request.

## 📄 Licencia
Este proyecto está bajo la Licencia MIT.

## 👨‍💻 Autor
**Jerson Salvador** - https://github.com/jersonsv
