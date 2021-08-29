using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Representa a entidade de domínio de usuários");
        }
    }
}
