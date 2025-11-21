using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Domain.Entities;

namespace InsightFlow.Documents.Api.Application.DTOs
{
    // --- RESPONSE ---

    /// <summary>
    /// DTO para la respuesta de documentos.
    /// </summary>
    public class DocumentResponse
    {
        public string Id { get; set; } = string.Empty;
        public string WorkspaceId { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<Block> Content { get; set; } = [];
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    // --- REQUESTS ---

    /// <summary>
    /// DTO para crear un documento.
    /// </summary>
    public class CreateDocumentDto
    {
        [Required(ErrorMessage = "WorkspaceId es requerido")]
        public string WorkspaceId { get; set; } = string.Empty;

        [Required(ErrorMessage = "UserId es requerido")]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
        public string Title { get; set; } = string.Empty;

        public string? Icon { get; set; }
    }

    /// <summary>
    /// DTO para actualizar. Propiedades anulables para indicar qué se quiere cambiar.
    /// </summary>
    public class UpdateDocumentDto
    {
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public List<Block>? Content { get; set; }
    }
}