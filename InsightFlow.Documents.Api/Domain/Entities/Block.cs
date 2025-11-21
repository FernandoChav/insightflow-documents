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
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Type { get; set; } // Tipo de bloque (e.g., "paragraph", "header", "image", etc.)
        
        public Dictionary<string, object> Data { get; set; } = new(); // Datos específicos del bloque

        public Block() { }

        public Block(string type, Dictionary<string, object> data)
        {
            Type = type;
            Data = data;
        }
    }
}