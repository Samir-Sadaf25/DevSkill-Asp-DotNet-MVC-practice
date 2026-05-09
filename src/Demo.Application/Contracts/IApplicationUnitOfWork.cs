using Demo.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Contracts
{
     public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
