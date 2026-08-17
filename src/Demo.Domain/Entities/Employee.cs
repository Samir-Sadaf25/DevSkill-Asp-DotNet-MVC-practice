using Demo.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Entities
{
    public class Employee 
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public  string? Phone { get; set; }
        public  double Salary { get; set; }
    }
}
