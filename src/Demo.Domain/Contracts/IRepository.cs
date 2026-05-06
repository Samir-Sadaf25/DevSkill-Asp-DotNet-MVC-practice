using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Contracts
{
    public interface IRepository<TAggregateRoot,TKey>
        where TAggregateRoot:class,IAggregateRoot<TKey>
        where TKey: IComparable
    {
        void add(TAggregateRoot entity);
        Task addAsync(TAggregateRoot entity);
    }
}
