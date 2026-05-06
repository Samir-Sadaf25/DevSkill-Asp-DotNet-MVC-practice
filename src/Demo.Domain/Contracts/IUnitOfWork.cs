using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void save();
        Task SaveAsync();
    }
}
