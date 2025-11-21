using AutoMapper;
using InsightFlow.Documents.Api.Application.DTOs;
using InsightFlow.Documents.Api.Application.Interfaces;
using InsightFlow.Documents.Api.Core.Wrappers;
using InsightFlow.Documents.Api.Domain.Entities;
using InsightFlow.Documents.Api.Domain.Interfaces;

namespace InsightFlow.Documents.Api.Application.Services
{
    public class DocumentService(IDocumentRepository repository, IMapper mapper) : IDocumentService
    {
        private readonly IDocumentRepository _repository = repository;
        private readonly IMapper _mapper = mapper; 

        public async Task<ApiResponse<DocumentResponse>> CreateDocumentAsync(CreateDocumentDto request)
        {
            // 1. Mapeo Automático (DTO -> Entity)
            var newDoc = _mapper.Map<Document>(request);
            
            // Lógica adicional que el mapper no debe saber (inicialización de lista)
            newDoc.Content = new List<Block>(); 

            // 2. Persistencia
            await _repository.AddAsync(newDoc);

            // 3. Mapeo Automático (Entity -> Response DTO)
            var responseDto = _mapper.Map<DocumentResponse>(newDoc);

            return new ApiResponse<DocumentResponse>(responseDto, "Documento creado exitosamente");
        }

        public async Task<ApiResponse<DocumentResponse>> GetDocumentByIdAsync(string id)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<DocumentResponse>("Documento no encontrado");

            // Mapeo Automático
            return new ApiResponse<DocumentResponse>(_mapper.Map<DocumentResponse>(doc));
        }

        public async Task<ApiResponse<DocumentResponse>> UpdateDocumentAsync(string id, UpdateDocumentDto request)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<DocumentResponse>("Documento no encontrado");

            // Para actualizaciones parciales (PATCH), a veces es mejor manual para control total,
            // pero aquí podemos usar el mapper si configuramos ignorar nulos.
            // Como ya lo hicimos manual antes y es más seguro para lógica de negocio crítica:
            if (request.Title != null) doc.Title = request.Title;
            if (request.Icon != null) doc.Icon = request.Icon;
            if (request.Content != null) doc.Content = request.Content;

            doc.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(doc);

            return new ApiResponse<DocumentResponse>(_mapper.Map<DocumentResponse>(doc), "Documento actualizado");
        }

        public async Task<ApiResponse<bool>> DeleteDocumentAsync(string id)
        {
            var doc = await _repository.GetByIdAsync(id);
            if (doc == null) return new ApiResponse<bool>("Documento no encontrado");

            await _repository.DeleteAsync(doc);

            return new ApiResponse<bool>(true, "Documento enviado a la papelera");
        }
    }
}