using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;

namespace RendaSolidaria.Infra.Data.GraphQL.UserExtensions
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Representa um comando para uma plataforma específica.");
        }
    }
}
