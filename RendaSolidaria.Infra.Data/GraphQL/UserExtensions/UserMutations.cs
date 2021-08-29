using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.GraphQL.UserExtensions
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UserMutations
    {
        [UseDbContext(typeof(MainContext))]
        public async Task<AddUserPayload> AddUser(AddUserInput input, [ScopedService] MainContext context)
        {
            var user = new User(input.name);

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return new AddUserPayload(user);
        }
    }
}
