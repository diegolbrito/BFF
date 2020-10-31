using System;

namespace BFF.SPA.Services.Core.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
