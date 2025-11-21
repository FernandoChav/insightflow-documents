using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Domain.Entities;

namespace InsightFlow.Documents.Api.Domain.Interfaces
{
    /// <summary>
    /// Define el contrato para el acceso a datos de la entidad Document.
    /// Sigue el patrón Repository para abstraer la persistencia.
    /// </summary>
    public interface IDocumentRepository
    {
        /// <summary>
        /// Obtiene todos los documentos activos del sistema.
        /// </summary>
        /// <returns>Una colección de documentos.</returns>
        Task<IEnumerable<Document>> GetAllAsync();

        /// <summary>
        /// Busca un documento específico por su identificador.
        /// </summary>
        /// <param name="id">El UUID del documento.</param>
        /// <returns>La entidad Document si se encuentra y está activa; de lo contrario, null.</returns>
        Task<Document?> GetByIdAsync(string id);

        /// <summary>
        /// Obtiene todos los documentos pertenecientes a un espacio de trabajo específico.
        /// </summary>
        /// <param name="workspaceId">El UUID del espacio de trabajo.</param>
        /// <returns>Lista de documentos del workspace.</returns>
        Task<IEnumerable<Document>> GetByWorkspaceIdAsync(string workspaceId);

        /// <summary>
        /// Persiste un nuevo documento en el almacén de datos.
        /// </summary>
        /// <param name="document">La entidad a crear.</param>
        Task AddAsync(Document document);

        /// <summary>
        /// Actualiza los datos de un documento existente.
        /// </summary>
        /// <param name="document">La entidad con los datos modificados.</param>
        Task UpdateAsync(Document document);

        /// <summary>
        /// Realiza un borrado lógico (Soft Delete) del documento.
        /// </summary>
        /// <param name="document">La entidad a desactivar.</param>
        Task DeleteAsync(Document document);
    }
}