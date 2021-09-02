using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using RendaSolidaria.Infra.Data.Repository;
using System.Linq;

namespace RendaSolidaria.API.GraphQL.UserExtensions
{
    [ExtendObjectType(OperationTypeNames.Query)]
   
    public class UserQueries
    {
        [UseDbContext(typeof(MainContext))]
        [UseFiltering]
        [UseSorting]
        //[Authorize]
        public IQueryable<User> GetUser([ScopedService] MainContext context, [Service] IUserRepository userRepository)
        {
            return userRepository.GetUsers(context);
        }
    }
}
