﻿using HotChocolate;

namespace RendaSolidaria.API.GraphQL
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Message);
        }
    }
}
