using RendaSolidaria.Core.Domain.Validation;

namespace RendaSolidaria.Core.Domain.Schemas
{
    public class User
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

        private bool IsValidDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name: Property name is required!");

            return true;
        }
    }
}
