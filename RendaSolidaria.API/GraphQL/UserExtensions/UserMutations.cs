using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using RendaSolidaria.Infra.Data.Repository;
using System;
using System.Threading.Tasks;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class UserMutations
    {
        [UseDbContext(typeof(MainContext))]
        public async Task<AddUserPayload> AddUser(AddUserInput input, [ScopedService] MainContext context, [Service] IUserRepository userRepository)
        {
            try
            {
                var user = new User(input.name);
                await userRepository.AddUserAsync(context, user);
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
        public async Task<UpdateUserPayload> UpdateUser(UpdateUserInput input, [ScopedService] MainContext context, [Service] IUserRepository userRepository)
        {
            try
            {
                var user= await userRepository.GetUserByIdAsync(context, input.id);
                if(user == null)
                {
                    throw new Exception("User not found");
                }

                user.Update(input.name);
                await userRepository.UpdateUserAsync(context, user);
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
