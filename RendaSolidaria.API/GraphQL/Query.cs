using HotChocolate;
using HotChocolate.Data;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data;
using RendaSolidaria.Infra.Data.Context;
using System.Linq;

namespace RendaSolidaria.API.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(MainContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUser(
            [ScopedService] MainContext context,
            [Service] IUserRepository userRepository
        )
        {
            return userRepository.GetUser(context);
        }
    }
}
