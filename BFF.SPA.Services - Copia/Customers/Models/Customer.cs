using BFF.SPA.Services.Core.Models;
using System;

namespace BFF.SPA.Services.Customers.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
