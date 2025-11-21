using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Domain.Entities;

namespace InsightFlow.Documents.Api.Infrastructure.Persistence
{/// <summary>
    /// Simula un contexto de base de datos en memoria (RAM).
    /// Debe ser registrado como Singleton para mantener los datos durante la vida de la aplicación.
    /// </summary>
    public class InMemoryDataContext
    {
        /// <summary>
        /// Colección volátil de documentos. Actúa como la tabla 'Documents'.
        /// </summary>
        public List<Document> Documents { get; set; }

        /// <summary>
        /// Inicializa el contexto y ejecuta el sembrado de datos (Seeder).
        /// </summary>
        public InMemoryDataContext()
        {
            Documents = [];
            SeedData();
        }

        /// <summary>
        /// Carga datos iniciales de prueba para cumplir con los requisitos de evaluación.
        /// </summary>
        private void SeedData()
        {
            // Seed 1: Documento de bienvenida
            Documents.Add(new Document
            {
                Id = "doc-seed-001",
                WorkspaceId = "ws-seed-001", // Asumiendo que este WS existe en el otro servicio
                OwnerId = "user-seed-001",
                Title = "Bienvenida a InsightFlow",
                Icon = "👋",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                Content =
                [
                    new Block("h1", new Dictionary<string, object> { { "text", "Hola Mundo" } }),
                    new Block("paragraph", new Dictionary<string, object> { { "text", "Este es un documento de prueba generado automáticamente." } })
                ]
            });

            // Seed 2: Lista de tareas (ejemplo)
            Documents.Add(new Document
            {
                Id = "doc-seed-002",
                WorkspaceId = "ws-seed-001",
                OwnerId = "user-seed-001",
                Title = "Project Roadmap",
                Icon = "🚀",
                IsActive = true,
                CreatedAt = DateTime.UtcNow.AddHours(-1),
                Content = new List<Block>
                {
                    new Block("h2", new Dictionary<string, object> { { "text", "Q4 Goals" } }),
                    new Block("todo", new Dictionary<string, object> { { "text", "Configurar CI/CD" }, { "checked", true } })
                }
            });
        }
    }
}