using Demo.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Data
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext dbContext,IProductRepository productRepository) : base(dbContext)
        {
            ProductRepository = productRepository;
        }
    }
}
