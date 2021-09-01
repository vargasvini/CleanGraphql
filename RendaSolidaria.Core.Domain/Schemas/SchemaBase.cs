using System;

namespace RendaSolidaria.Core.Domain.Schemas
{
    public class SchemaBase
    {
        public SchemaBase()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
