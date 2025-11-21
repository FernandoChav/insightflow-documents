using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsightFlow.Documents.Api.Application.DTOs;
using InsightFlow.Documents.Api.Application.Interfaces;
using InsightFlow.Documents.Api.Core.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace InsightFlow.Documents.Api.Controllers
{
    [ApiController]
    [Route("api/documents")] // La ruta base según el enunciado
    public class DocumentsController(IDocumentService service) : ControllerBase
    {
        private readonly IDocumentService _service = service;

        /// <summary>
        /// Crea un nuevo documento en el espacio de trabajo especificado.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateDocumentDto request)
        {
            var response = await _service.CreateDocumentAsync(request);

            // Retornamos 201 Created si fue exitoso
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);
            }

            return BadRequest(response);
        }

        /// <summary>
        /// Obtiene un documento por su ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _service.GetDocumentByIdAsync(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        /// <summary>
        /// Actualiza el contenido o metadatos de un documento.
        /// </summary>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<DocumentResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateDocumentDto request)
        {
            var response = await _service.UpdateDocumentAsync(id, request);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        /// <summary>
        /// Realiza un borrado lógico (Soft Delete) del documento.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _service.DeleteDocumentAsync(id);

            if (!response.Success) return NotFound(response);

            return Ok(response);
        }
    }
}