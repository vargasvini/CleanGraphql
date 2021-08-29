using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Threading.Tasks;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UserMutations
    {
        [UseDbContext(typeof(MainContext))]
        public async Task<AddUserPayload> AddUser(AddUserInput input, [ScopedService] MainContext context)
        {
            try
            {
                var user = new User(input.name);
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return new AddUserPayload(user);
            }
            catch (System.Exception ex)
            {
                var userpl = new AddUserPayload(null);
                userpl.IsSuccess = false;
                userpl.ErrorMessage = ex.Message;
                return userpl;
            }
        }
    }
}
