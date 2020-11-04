using System;

namespace BFF.APP.Services.Core.Models
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
