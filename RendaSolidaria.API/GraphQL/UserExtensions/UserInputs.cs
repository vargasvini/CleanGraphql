namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    public record AddUserInput(string name);
    public record UpdateUserInput(int id, string name);
}
