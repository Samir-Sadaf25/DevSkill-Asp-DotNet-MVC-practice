using Cortex.Mediator.Commands;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Features.Products.Command.Delete
{
    public class ProductDeleteCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
