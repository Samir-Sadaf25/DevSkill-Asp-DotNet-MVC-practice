using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Contracts
{
    public interface IServerTime
    {
        DateTime DateTime { get; }
    }
}
