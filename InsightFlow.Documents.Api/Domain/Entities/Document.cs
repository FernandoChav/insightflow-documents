using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsightFlow.Documents.Api.Domain.Entities
{
    /// <summary>
    /// Representa un documento en el sistema.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Identificador único del documento.
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Identificador del espacio de trabajo al que pertenece el documento.
        /// </summary>
        /// <value></value>
        public string WorkspaceId { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del propietario del documento.
        /// </summary>
        /// <value></value>
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// Título del documento.
        /// </summary>
        /// <value></value>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Icono representativo del documento.
        /// </summary>
        /// <value></value>
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// Contenido del documento, compuesto por bloques de texto, imágenes, etc.
        /// </summary>
        /// <value></value>
        public List<Block> Content { get; set; } = new();
        /// <summary>  
        /// Indica si el documento está activo o ha sido eliminado lógicamente.
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// Fecha y hora de creación del documento. 
        /// </summary>
        /// <value></value>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Fecha y hora de la última actualización del documento.  
        /// </summary>
        /// <value></value>
        public DateTime? UpdatedAt { get; set; } 
        /// <summary>
        /// Fecha y hora de eliminación del documento. 
        /// </summary>
        /// <value></value>
        public void UpdateContent(string title, string icon, List<Block> content)
        {
            if (!string.IsNullOrEmpty(title)) Title = title;
            if (!string.IsNullOrEmpty(icon)) Icon = icon;
            if (content != null) Content = content;
            
            UpdatedAt = DateTime.UtcNow;
        }
        /// <summary>
        /// Marca el documento como eliminado lógicamente.
        /// </summary>
        public void Delete()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}