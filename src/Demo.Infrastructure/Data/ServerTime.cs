using Demo.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure.Data
{
    internal class ServerTime : IServerTime
    {
        public DateTime DateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
