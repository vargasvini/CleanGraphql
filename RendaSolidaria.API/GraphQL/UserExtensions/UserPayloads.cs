using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    public record AddUserPayload(User user) : PayloadBase();
    public record UpdateUserPayload(User user) : PayloadBase();
}
