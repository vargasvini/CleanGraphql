using HotChocolate;
using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public IQueryable<User> GetUsers([ScopedService] MainContext context)
        {
            return context.Users;
        }
    }
}
