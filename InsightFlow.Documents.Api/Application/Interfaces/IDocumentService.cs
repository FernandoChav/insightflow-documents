using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Application.DTOs;
using InsightFlow.Documents.Api.Core.Wrappers;

namespace InsightFlow.Documents.Api.Application.Interfaces
{
    /// <summary>
    /// Define la lógica de negocio para la gestión de documentos.
    /// </summary>
    public interface IDocumentService
    {
        Task<ApiResponse<DocumentResponse>> CreateDocumentAsync(CreateDocumentDto request);
        Task<ApiResponse<DocumentResponse>> GetDocumentByIdAsync(string id);
        Task<ApiResponse<DocumentResponse>> UpdateDocumentAsync(string id, UpdateDocumentDto request);
        Task<ApiResponse<bool>> DeleteDocumentAsync(string id);
    }
}