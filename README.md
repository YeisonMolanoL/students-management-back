# 🎯 Backend API - Proyecto .NET 8

Este repositorio contiene la API backend desarrollada con **.NET 8**, diseñada para gestionar operaciones relacionadas con estudiantes, asignaturas y otros recursos del sistema.

---

## ✅ Requisitos

Antes de comenzar, asegúrate de tener instalado lo siguiente:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/) o [Visual Studio Code](https://code.visualstudio.com/)
- MySql local en el puerto 3306
- Git

---

## 🚀 Cómo levantar el proyecto localmente

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/nombre-del-repo.git
cd nombre-del-repo# Student management
```

### 2. Ejecutar Restore

```bash
En la consola de powershell
--->  dotnet restore
```

### 3. Ejecutar update database

```bash
Tu configuración actual:
    "DefaultConnection": "server=localhost;port=3306;database=students-course;uid=root;password=tour_password"
Si gustas cambiarla lo puedes hacer en root o directorio base del proyecto y:
--->  root>appsetting.json
Seguido de esto ejecutas nuevamente en la consola de powershell:
--->  "dotnet ef database update"
para el ajuste automatico de la base de datos
```

### 4. Correr el proyecto para iniciar a realizar peticiones.

```bash
En la consola de powershell:
--->  dotnet run
El servidor estará escuchando por el puerto 7073 para realizar peticiones
```
