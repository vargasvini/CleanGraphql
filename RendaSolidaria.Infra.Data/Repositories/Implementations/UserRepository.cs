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
        public async Task AddUserAsync(MainContext context, User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(MainContext context, int id)
        {
            return await context.Users.FindAsync(id);
        }

        public IQueryable<User> GetUsers([ScopedService] MainContext context)
        {
            return context.Users;
        }

        public async Task UpdateUserAsync(MainContext context, User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
