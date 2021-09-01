using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System;
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
            catch (Exception ex)
            {
                var userpl = new AddUserPayload(null);
                userpl.IsSuccess = false;
                userpl.ErrorMessage = ex.Message;
                return userpl;
            }
        }

        [UseDbContext(typeof(MainContext))]
        public async Task<UpdateUserPayload> UpdateUser(UpdateUserInput input, [ScopedService] MainContext context)
        {
            try
            {
                var user= await context.Users.FindAsync(input.id);
                if(user == null)
                {
                    throw new Exception("User not found");
                }

                user.Update(input.name);
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return new UpdateUserPayload(user);
            }
            catch (Exception ex)
            {
                var userpl = new UpdateUserPayload(null);
                userpl.IsSuccess = false;
                userpl.ErrorMessage = ex.Message;
                return userpl;
            }
        }
    }
}
