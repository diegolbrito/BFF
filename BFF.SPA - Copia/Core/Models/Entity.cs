using System;

namespace BFF.SPA.Core.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
