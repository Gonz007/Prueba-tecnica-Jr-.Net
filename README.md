# Prueba-tecnica-Jr-.Net
Desarrollo de sistema basico de gestion de hoteles con Backend en .Net core y front Angular 16.


Resumen del Proyecto: Sistema de Gestión de Hoteles

Backend: API de Hoteles
Tecnologías:

ASP.NET Core (C#)
Entity Framework Core
SQL Server
Funcionalidades:

CRUD para gestión de hoteles.
Endpoint para obtener información de hoteles con filtrado y paginación.
Consulta de Ejemplo:

sql
Copy code
SELECT TOP (1000) [Id], [Name], [Stars] FROM [HotelsBd].[dbo].[Hotels] ORDER BY Id;
Frontend: Aplicación Angular
Tecnologías:

Angular (TypeScript)
Angular Material
Funcionalidades:

Lista de hoteles con paginación.
Búsqueda y filtrado de hoteles.
Imágenes aleatorias de hoteles desde Unsplash.
Estructura del Proyecto:

Backend: Carpetas Controllers y Services.
Frontend: Componentes para lista, detalles y búsqueda.
Consideraciones Adicionales:
Script SQL para insertar 40 registros de ejemplo.
Página responsive para dispositivos móviles y de escritorio.
Optimización para entornos productivos.
