using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.Repository
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers(MainContext context);
        Task<User> GetUserByIdAsync(MainContext context, int id);
        Task AddUserAsync(MainContext context, User user);
        Task UpdateUserAsync(MainContext context, User user);
    }
}
