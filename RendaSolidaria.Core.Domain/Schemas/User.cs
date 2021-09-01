using RendaSolidaria.Core.Domain.Validation;
using System;

namespace RendaSolidaria.Core.Domain.Schemas
{
    public class User : SchemaBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            if (IsValidDomain(name))
            {
                Name = name;
            }
        }

        public void Update(string name)
        {
            if (IsValidDomain(name))
            {
                Name = name;
                base.UpdatedAt = DateTime.Now;
            }
        }

        private bool IsValidDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name: Property name is required!");

            return true;
        }
    }
}
