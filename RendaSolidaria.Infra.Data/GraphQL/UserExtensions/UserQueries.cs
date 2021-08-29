using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Linq;

namespace RendaSolidaria.Infra.Data.GraphQL.UserExtensions
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UserQueries
    {
        [UseDbContext(typeof(MainContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUser([ScopedService] MainContext context)
        {
            return context.Users;
        }
    }
}
