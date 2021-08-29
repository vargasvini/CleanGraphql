using RendaSolidaria.Core.Domain.Schemas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RendaSolidaria.Core.Domain
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
    }
}
