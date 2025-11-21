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
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string WorkspaceId { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public List<Block> Content { get; set; } = new();

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } 

        public void UpdateContent(string title, string icon, List<Block> content)
        {
            if (!string.IsNullOrEmpty(title)) Title = title;
            if (!string.IsNullOrEmpty(icon)) Icon = icon;
            if (content != null) Content = content;
            
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}