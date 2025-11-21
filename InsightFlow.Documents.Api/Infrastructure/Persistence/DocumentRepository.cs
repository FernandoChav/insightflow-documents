using InsightFlow.Documents.Api.Domain.Entities;
using InsightFlow.Documents.Api.Domain.Interfaces;
namespace InsightFlow.Documents.Api.Infrastructure.Persistence
{
    /// <summary>
    /// Implementación del repositorio utilizando persistencia en memoria.
    /// </summary>
    /// <remarks>
    /// Inyecta el contexto de datos.
    /// </remarks>
    /// <param name="context">Instancia Singleton del contexto en memoria.</param>
    public class DocumentRepository(InMemoryDataContext context) : IDocumentRepository
    {
        private readonly InMemoryDataContext _context = context;

        /// <inheritdoc />
        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            // Filtramos solo los activos (Soft Delete check)
            var activeDocs = _context.Documents.Where(d => d.IsActive);
            return await Task.FromResult(activeDocs);
        }

        /// <inheritdoc />
        public async Task<Document?> GetByIdAsync(string id)
        {
            var doc = _context.Documents.FirstOrDefault(d => d.Id == id && d.IsActive);
            return await Task.FromResult(doc);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Document>> GetByWorkspaceIdAsync(string workspaceId)
        {
            var docs = _context.Documents
                .Where(d => d.WorkspaceId == workspaceId && d.IsActive);
            return await Task.FromResult(docs);
        }

        /// <inheritdoc />
        public async Task AddAsync(Document document)
        {
            _context.Documents.Add(document);
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Document document)
        {
            // En memoria, como pasamos objetos por referencia, la actualización suele ser automática
            // si modificamos el objeto recuperado. Sin embargo, para cumplir el contrato:
            var existingIndex = _context.Documents.FindIndex(d => d.Id == document.Id);
            if (existingIndex != -1)
            {
                _context.Documents[existingIndex] = document;
            }
            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task DeleteAsync(Document document)
        {
            // Implementación de Soft Delete requerida por rúbrica
            document.Delete(); // Llama al método de dominio IsActive = false
            await UpdateAsync(document);
        }
    }
}