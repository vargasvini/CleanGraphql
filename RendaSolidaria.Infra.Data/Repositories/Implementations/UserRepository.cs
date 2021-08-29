using HotChocolate;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Linq;

namespace RendaSolidaria.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public IQueryable<User> GetUser([ScopedService] MainContext context)
        {
            return context.Users;
        }
    }
}
