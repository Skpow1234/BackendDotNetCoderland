
# Proyecto Backend PruebaCoderland

## Descripción

Este proyecto es una aplicación backend desarrollada en C# que utiliza Entity Framework para la conexión y manipulación de una base de datos PostgreSQL. Incluye pruebas unitarias utilizando XUnit y la configuración de entornos de desarrollo y pruebas con Docker Compose.

## Estructura del Proyecto

El proyecto está dividido en varias capas y carpetas para mantener la arquitectura limpia y escalable:

- **Application:** Contiene la lógica de la aplicación, como controladores, servicios y casos de uso.
- **Domain:** Aquí se encuentran las entidades y lógicas del dominio de la aplicación.
- **Infrastructure:** Esta capa maneja la interacción con la base de datos y cualquier otro servicio externo.
- **Shared:**y
  - **Common:** Incluye clases y enumeraciones compartidas entre diferentes partes de la aplicación.
    - `BaseOut`: Clase para estructurar respuestas con mensajes y resultados.
    - `Result`: Enum que define diferentes tipos de resultados posibles en las operaciones de la aplicación (Success, Error, NoRecords, etc.).
- **UnitTest:** Contiene las pruebas unitarias implementadas utilizando XUnit para validar la funcionalidad de la aplicación.
- **Docker:** El proyecto está preparado para ejecutarse con Docker utilizando los archivos `docker-compose.yml` y `docker-compose.override.yml`, que configuran los servicios necesarios.

## Funcionalidades

### Conexión a Base de Datos

El proyecto está configurado para conectarse a una base de datos PostgreSQL utilizando Entity Framework. La clase `DbContext` maneja las conexiones y operaciones con la base de datos.

### Migración y Seed Data

Se ha implementado una migración que genera la tabla `CarBrand` en la base de datos. Además, se ha desarrollado un mecanismo de seed data para inicializar esta tabla con al menos tres marcas de autos de ejemplo.

### API REST

El controlador `CarBrandController` expone un endpoint que permite obtener todas las marcas de autos desde la base de datos.

### Pruebas Unitarias

Se han implementado pruebas unitarias con XUnit para asegurar que el endpoint de `CarBrandController` devuelve los datos esperados. El entorno de pruebas incluye un contexto de base de datos en memoria para una validación rápida y eficiente de la funcionalidad.

### Docker Compose

El proyecto incluye un archivo `docker-compose.yml` que configura los siguientes servicios:

- **PostgreSQL:** Servicio para la base de datos.
- **API REST:** Servicio que expone la API de la aplicación y se conecta a la base de datos PostgreSQL.

El archivo `docker-compose.override.yml` permite personalizar configuraciones adicionales para el entorno de desarrollo.

## Requisitos

- **.NET 8.0**
- **Docker**
- **PostgreSQL**

## Ejecución del Proyecto

1. Clonar este repositorio.
2. Asegurarse de tener Docker instalado y funcionando.
3. Ejecutar el siguiente comando para iniciar los servicios:

   ```bash
   docker-compose up --build
   ```

4. La API estará disponible en `http://localhost:5000` y la base de datos PostgreSQL en el puerto `5432`.

## Ejecución de las Pruebas Unitarias

Para ejecutar las pruebas unitarias, utiliza el siguiente comando dentro de la carpeta del proyecto:

```bash
dotnet test
```

## Notas Adicionales

- Se ha seguido el patrón de buenas prácticas de codificación, y el código está comentado cuando es necesario para una mayor comprensión.
- La cobertura de las pruebas unitarias alcanza el 70%.
