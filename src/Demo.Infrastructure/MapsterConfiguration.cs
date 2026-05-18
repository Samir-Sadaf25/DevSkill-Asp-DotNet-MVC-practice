using Demo.Application.Features.Products.Command;
using Demo.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductAddCommand, Product>();
        }
    }
}
