using Microsoft.EntityFrameworkCore;
using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
