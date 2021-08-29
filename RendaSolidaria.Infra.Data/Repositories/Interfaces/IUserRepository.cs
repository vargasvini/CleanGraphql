using RendaSolidaria.Core.Domain.Schemas;
using RendaSolidaria.Infra.Data.Context;
using System.Linq;

namespace RendaSolidaria.Infra.Data
{ 
    public interface IUserRepository
    {
        public IQueryable<User> GetUser(MainContext context);
    }
}
