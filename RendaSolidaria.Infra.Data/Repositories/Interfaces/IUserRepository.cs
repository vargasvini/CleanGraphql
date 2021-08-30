using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.Repository
{
    public interface IUserRepository
    {
        public IQueryable<User> GetUsers(MainContext context);
    }
}
