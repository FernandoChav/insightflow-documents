# InsightFlow - Documents Service

Microservicio encargado de la gestión de documentos y contenido estructurado para la plataforma InsightFlow.

## 🏗 Arquitectura

Este servicio sigue los principios de **Clean Architecture** y **SOLID**, estructurado en capas para asegurar la mantenibilidad y escalabilidad:

* **Domain:** Entidades (`Document`, `Block`) e Interfaces del Repositorio. Sin dependencias externas.
* **Application:** Lógica de negocio (`DocumentService`), DTOs y Mapeos (AutoMapper). Implementa el patrón Mediator (simplificado vía Servicios).
* **Infrastructure:** Implementación de persistencia en memoria (`InMemoryDataContext`) y Repositorios.
* **Presentation:** Controladores API RESTful.

**Patrones utilizados:**
* **Repository Pattern:** Para abstraer la capa de datos.
* **Dependency Injection:** Para desacoplar componentes.
* **Singleton:** Para mantener la persistencia en memoria volátil.

## 🚀 Ejecución Local

1. Clonar el repositorio.
2. Navegar a la carpeta de la API.
3. Ejecutar: `dotnet run`
4. Acceder a Swagger: `http://localhost:XXXX/swagger`

## 🐳 Docker

```bash
docker build -t insightflow-documents .
docker run -p 8080:8080 insightflow-documents
---

### Tu Próximo Movimiento (Configuración de Secretos)

Para que el archivo `.yml` funcione y no te de error en GitHub, necesitas configurar las "Secrets" en tu repositorio de GitHub.

1.  Ve a tu repo en GitHub -> **Settings** -> **Secrets and variables** -> **Actions**.
2.  Agrega estas variables:
    * `DOCKER_USERNAME`: Tu usuario de Docker Hub.
    * `DOCKER_PASSWORD`: Tu contraseña (o Access Token) de Docker Hub.
    * `RENDER_DEPLOY_HOOK`: La URL que te dará Render cuando crees el servicio (esto lo haremos luego, pero tenlo en mente).