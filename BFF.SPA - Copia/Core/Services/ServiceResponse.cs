using System.Collections.Generic;
using System.Linq;

namespace BFF.SPA.Core.Services
{
    public class ServiceResponse<T>
    {
        public List<string> Notifications { get; set; }
        public T Data { get; set; }
        public void AddNotification(params string[] notification) => Notifications.AddRange(notification?.Where(p => !string.IsNullOrWhiteSpace(p)));
    }
}
