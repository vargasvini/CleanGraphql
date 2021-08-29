using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    public record AddUserPayload(User user) : PayloadBase();
}
