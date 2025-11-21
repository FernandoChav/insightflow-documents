using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsightFlow.Documents.Api.Domain.Entities
{
    /// <summary>
    /// Representa un bloque de contenido dentro de un documento (Párrafo, H1, Imagen, etc.)
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Identificador único del bloque
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();
    
        /// <summary>
        /// Tipo de bloque (por ejemplo, "paragraph", "header", "image", etc.)
        /// </summary>
        public string Type { get; set; } = string.Empty; 
        
        /// <summary>
        /// Datos asociados al bloque
        /// </summary>
        public Dictionary<string, object> Data { get; set; } = new(); 
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Block() { }
        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="type">Tipo de bloque</param>
        /// <param name="data">Datos del bloque</param>
        /// <returns></returns>
        public Block(string type, Dictionary<string, object> data)
        {
            Type = type;
            Data = data;
        }
    }
}