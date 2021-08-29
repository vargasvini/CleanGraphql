using RendaSolidaria.Core.Domain.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendaSolidaria.Infra.Data.GraphQL.UserExtensions
{
    public record AddUserPayload(User user);
}
