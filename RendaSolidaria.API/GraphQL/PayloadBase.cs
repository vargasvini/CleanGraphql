using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    public record PayloadBase
    {
        public PayloadBase()
        {
            IsSuccess = true;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
