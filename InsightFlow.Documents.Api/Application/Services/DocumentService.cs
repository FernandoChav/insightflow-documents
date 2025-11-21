using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Application.DTOs;
using InsightFlow.Documents.Api.Application.Interfaces;
using InsightFlow.Documents.Api.Core.Wrappers;
using InsightFlow.Documents.Api.Domain.Entities;
using InsightFlow.Documents.Api.Domain.Interfaces;

namespace InsightFlow.Documents.Api.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<DocumentResponse>> CreateDocumentAsync(CreateDocumentDto request)
        {
            // 1. Mapeo Manual (Request -> Entity)
            var newDoc = new Document
            {
                WorkspaceId = request.WorkspaceId,
                OwnerId = request.UserId,
                Title = request.Title,
                Icon = request.Icon ?? "📄", // Icono por defecto
                Content = new List<Block>(), // Inicia vacío según enunciado
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            // 2. Persistencia
            await _repository.AddAsync(newDoc);

            // 3. Mapeo Manual (Entity -> Response)
            var responseDto = MapToResponse(newDoc);

            return new ApiResponse<DocumentResponse>(responseDto, "Documento creado exitosamente");
        }

        public async Task<ApiResponse<DocumentResponse>> GetDocumentByIdAsync(string id)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<DocumentResponse>("Documento no encontrado");

            return new ApiResponse<DocumentResponse>(MapToResponse(doc));
        }

        public async Task<ApiResponse<DocumentResponse>> UpdateDocumentAsync(string id, UpdateDocumentDto request)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<DocumentResponse>("Documento no encontrado");

            // Actualización parcial (solo lo que viene en el DTO)
            if (request.Title != null) doc.Title = request.Title;
            if (request.Icon != null) doc.Icon = request.Icon;
            if (request.Content != null) doc.Content = request.Content;

            doc.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(doc);

            return new ApiResponse<DocumentResponse>(MapToResponse(doc), "Documento actualizado");
        }

        public async Task<ApiResponse<bool>> DeleteDocumentAsync(string id)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<bool>("Documento no encontrado");

            await _repository.DeleteAsync(doc); // Esto hace el Soft Delete internamente

            return new ApiResponse<bool>(true, "Documento enviado a la papelera");
        }

        // Helper privado para mapear (Evita repetir código hasta que pongamos AutoMapper)
        private DocumentResponse MapToResponse(Document doc)
        {
            return new DocumentResponse
            {
                Id = doc.Id,
                WorkspaceId = doc.WorkspaceId,
                OwnerId = doc.OwnerId,
                Title = doc.Title,
                Icon = doc.Icon,
                Content = doc.Content,
                IsActive = doc.IsActive,
                CreatedAt = doc.CreatedAt,
                UpdatedAt = doc.UpdatedAt
            };
        }
    }
}