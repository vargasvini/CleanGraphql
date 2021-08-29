using RendaSolidaria.Core.Domain.Schemas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
    }
}
