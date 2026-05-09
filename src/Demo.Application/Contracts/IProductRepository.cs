using Demo.Domain.Contracts;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Contracts
{
    public interface IProductRepository : IRepository<Product,Guid>
    {
    }
}
